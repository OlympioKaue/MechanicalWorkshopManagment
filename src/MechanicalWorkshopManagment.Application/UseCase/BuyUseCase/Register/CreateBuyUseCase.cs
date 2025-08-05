using Mapster;
using MechanicalWorkshopManagment.Application.Mapster;
using MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System.Diagnostics;
using System.IO;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Register
{
    public class CreateBuyUseCase : ICreateBuyUseCase
    {

        private readonly IBuys _buys;
        private readonly ISaveChangesWorks _save;
        private readonly IStockMovements _movements;
        private readonly ICustomer _customer;
        private readonly IPartsBudgets _partsBudgets;

        public CreateBuyUseCase(IBuys buys, ISaveChangesWorks save
            , IStockMovements movements, ICustomer customer, IPartsBudgets partsBudgets)
        {
            _buys = buys;
            _save = save;
            _movements = movements;
            _customer = customer;
            _partsBudgets = partsBudgets;
        }



        public async Task<List<ResponseBuyCreate>> RegistrationBuyExecute(RequestBuyDTO createBuy, int idCustomer)
        {
            //Valida os dados da request.
            Validate(createBuy);

            //Mapeia o DTO para entidade buy.
            var buyMapping = createBuy.Adapt<Buy>();

            //Agrupamento de erros.
            var messageErrors = new List<string>();

            //O cliente existe ?
            var partsBudgetCustomerExist = await _customer.GetCustomerByFirstOrDefaultID(idCustomer);
            if (partsBudgetCustomerExist is null)
                //Adicione o erro na lista de mensagem.
                messageErrors.Add($"O cliente com o id({idCustomer}) não encontrado.)");

            //Contém erros na lista?
            if (messageErrors.Any())
                //Exceção 404.
                throw new NotFoundException(string.Join(" | ", messageErrors)); // Retorne o erro para o usuário 404.

            // Retorno para o usuário em list (Todas peças compradas).
            var responseListAccept = new List<ResponseBuyCreate>();

            //Data e hora da compra.
            var currentDate = DateTime.UtcNow;


            //Filtre apenas o orçamentoPeça marcado como espera.
            var partsBudgetItens = partsBudgetCustomerExist!.PartsBudget.Where(pb =>
                    pb.BudgetStatus != PartsBudgetStatus.Finished).ToList();

            //Se não conter orçamentos marcado em espera, gere o erro.
            if (!partsBudgetItens.Any())
                //Exceção 404.
                throw new NotFoundException("Não existe orçamentos vinculado a este id, compra negada.");


            //Calcula o total esperado da compra antes de qualquer ação.
            decimal ExpectedTotal = 0;


            //Loop para agrupa o total das peças adicionadas no orçamentoPeça.
            foreach (var itensPartsBudgetBuy in partsBudgetItens)
            {
                //Caso não exista a peça.
                if (itensPartsBudgetBuy is null)
                    //Exceção 404.
                    throw new NotFoundException($"Peça com ID {itensPartsBudgetBuy?.PartsId} não encontrada no orçamento.");

                //Preço com desconto, inicialmente igual ao cadastrado.
                var registeredPriceWithDiscount = itensPartsBudgetBuy.AppliedPrice;

                //Guarde o total comprado pelo usuário.
                ExpectedTotal += registeredPriceWithDiscount * itensPartsBudgetBuy.Quantity;

            }

            //Guarde o erro caso o preço via request < que o totalAcumulado.
            if (createBuy.CostPrice < ExpectedTotal)
            {
               //Deleta do orçamentoPeça compras negada.
               await _partsBudgets.DeletePartsBudgetPurchaseDenied(partsBudgetItens);

                //Adicione o erro na lista de mensagem.
                messageErrors.Add($"O valor informado ({createBuy.CostPrice}) é menor que o total esperado ({ExpectedTotal}). Orçamento excluido, " +
                    $"Compra negada.");
               
            }
               
                

            //Contém erros na lista?
            if (messageErrors.Any())
                //Exceção 400.
                throw new OnExceptionSystem(string.Join(" | ", messageErrors));


            //Loop para percorrer a lista e adicionar no banco.
            foreach (var browseBuyList in partsBudgetItens)
            {
                //Peça não encontrada, guarda na lista de erros.
                if (browseBuyList is null || browseBuyList?.PartsId is null || browseBuyList.PartsId <= 0)
                {
                    //Adicione o erro na lista de mensagem.
                    messageErrors.Add($"Peça com ID {browseBuyList?.PartsId} não encontrada no orçamentoPeça.");
                    continue;

                }


                //Insira no banco.
                var buy = new Buy
                {
                    CustomerId = idCustomer, // id do Cliente.
                    PartsId = browseBuyList.PartsId, // id da Peça.
                    Quantity = browseBuyList.Quantity, // Quantidade pedida.
                    CostPrice = createBuy.CostPrice, // preço passado pelo cliente.
                    AmountReceivable = createBuy.CostPrice > ExpectedTotal // Troco.
                    ? createBuy.CostPrice - ExpectedTotal : null,
                    Date = currentDate, // data da compra.
                    PurchaseStatus = PurchaseStatus.Finished, // compra finalizada.
                    StatusDelivered = DeliveredStatus.InWaiting, // entrega em espera.

                };



                //Atualiza estoque e estado da peça.
                browseBuyList.Parts.Quantity -= browseBuyList.Quantity;

                //Define o estado no orçamentoPeça como finalizado.
                browseBuyList.BudgetStatus = PartsBudgetStatus.Finished;


                //Será diferente caso o cliente conseguiu desconto na peça.
                if (browseBuyList.AppliedPrice != browseBuyList.Parts.Price)
                    // Atualiza o orçamentoPeça, devido o desconto aplicado a este cliente com a peça selecionada.
                    browseBuyList.TotalPrice = browseBuyList.AppliedPrice * browseBuyList.Quantity;


                //Atualiza a saída da peça no estoque.
                var addMovementsExit = new StockMovement
                {
                    PartsId = browseBuyList.PartsId, // id da peça.
                    Quantity = browseBuyList.Quantity, // quantidade solicitada.
                    Date = currentDate, // data da compra.
                    Movements = MovementsStatus.Exit // saida do estoque.
                };


                //Adiciona a compra no banco.
                await _buys.AddBuys(buy);


                //Salve os dados da saída.
                await _movements.AddStockMovementAsync(addMovementsExit);


                //Salve os dados.
                await _save.SaveChangesAsync();



                //Armazene no retorno para o cliente.
                responseListAccept.Add(new ResponseBuyCreate
                {

                    Id = buy.Id, // id da compra.
                    Date = currentDate.Date, // data da compra.
                    AmountReceivable = buy.AmountReceivable ?? 0, // valor a receber.
                    Movements = MovementsStatus.Exit.ToString(), // saida do estoque.
                    Quantity = browseBuyList.Quantity // quantidade comprada.
                });


            }

            //Contém erros na lista ?
            if (!responseListAccept.Any())
                throw new OnExceptionSystem(messageErrors.Any()
                    ? messageErrors
                    : new List<string> { "Nenhuma compra foi processada." });


            //Retorne para o usuário.
            return responseListAccept;


        }

        private void Validate(RequestBuyDTO createBuy)
        {
            //Instancie o validator.
            var validation = new ValidatorBuyUseCase();

            //Valide os dados.
            var resultValidation = validation.Validate(createBuy);

            //Se conter erros.
            if (resultValidation.IsValid is false)
            {
                //Agrupa os erros via request.
                var erro = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

                //Lançe a exceção.
                throw new OnExceptionSystem(erro);
            }
        }

    }
}
