using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Update
{
    public class UpdatePartsBudgetUseCase : IUpdatePartsBudgetUseCase
    {
        private readonly ICustomer _customer;
        private readonly IPartsBudgets _partsBudget;
        private readonly IParts _parts;
        private readonly ISaveChangesWorks _save;

        public UpdatePartsBudgetUseCase(ICustomer customer, IPartsBudgets partsBudget, IParts parts, ISaveChangesWorks save)
        {
            _customer = customer;
            _partsBudget = partsBudget;
            _parts = parts;
            _save = save;
        }

        public async Task UpdatePartsBudgetExecute(RequestPartBudgetListDTO updatePartBudget, int idCustomer)
        {
            //Valida os dados.
            Validate(updatePartBudget);

            // Busque se existe um cliente com esse id.
            var customerExists = await _customer.GetCustomerByAnyId(idCustomer);
            if (customerExists is false)
                //Exceção 404.
                throw new NotFoundException($"Cliente com o Id:({idCustomer}) não encontrado.");


            //Existe um cliente vinculado ao orçamentoPeça ?, se houver retorne um lista.
            var partsBudgetListAnyExists = await _partsBudget.GetPartsBudgetWithList(idCustomer);
            if (!partsBudgetListAnyExists.Any())
                //Exceção 404.
                throw new NotFoundException("Não existe orçamento vinculado ao Id fornecido.");


            // Lista para armazenar mensagens de exceção ou sucesso.
            var messageList = new List<string>();

            // Acumulador para o preço total de todas as peças, Incialmente com 0.
            var TotalAccumulatorPrice = 0; 


            //Loop para cada peça no orçamentoPeça.
            foreach (var partBudgetByRequest in updatePartBudget.partBudget)
            {

                // Verifica se a peça existe com o ID fornecido via Request.
                var partExists = await _parts.ThisPartsExistsWithID(partBudgetByRequest.PartsId);
                if (partExists is null)
                    //Exceção 404.
                    throw new NotFoundException($"Peça com Id:({partBudgetByRequest.PartsId}) não encontrado.");


                // Quantidade disponível da peça no estoque.
                var quantityOfPartsAvailable = partExists.Quantity;


                // Valida quantidade disponível.
                if (partBudgetByRequest.Quantity > quantityOfPartsAvailable)
                {
                    //Adicione a lista as peças indisponíveis.
                    messageList.Add($"Quantidade solicitada para a peça:({partExists.Id}), indisponível, quantidade para essa peça disponível:({quantityOfPartsAvailable}).");
                    continue;
                }

                // Preço original da peça.
                var originalPrice = partExists.Price;

                // Cliente tera desconto ?, se a quantidade de peça for >= 3, obtenha desconto de 10%.
                var discountedPrice = partBudgetByRequest.Quantity >= 3 ? originalPrice * 0.9m : originalPrice;

                // Preço total com desconto aplicado.
                var totalPrice = discountedPrice * partBudgetByRequest.Quantity;

                // Acumula o preço total para todas as peças.
                TotalAccumulatorPrice += (int)totalPrice;


                // Filtre apenas o id(via request) == id(Banco), e retorne em List.
                var existPartsBudget = partsBudgetListAnyExists
                    .Where(p => p.PartsId == partBudgetByRequest.PartsId).ToList(); 
                if (!existPartsBudget.Any())
                {
                    //Caso não exista a peça, adicione a lista de mensagem, não pare o programa.
                    messageList.Add($"Peça com Id:({partBudgetByRequest.PartsId}) não localizada no orçamentoPeça para atualização.");
                    continue;
                }


                // Filtre apenas o estado de confirmado.
                var EditionValue = existPartsBudget.Any(b =>
                    b.BudgetStatus != PartsBudgetStatus.Finished);

                // Se true.
                if (EditionValue) 
                {
                    //Faça um loop de atualização do orçamento.
                    foreach (var update in existPartsBudget)
                    {
                        update.Quantity = partBudgetByRequest.Quantity; // atuailze a quantidade.
                        update.AppliedPrice = discountedPrice; // atualize o desconto.
                        update.TotalPrice = totalPrice; // atualize o total.
                        update.BudgetStatus = PartsBudgetStatus.InWaiting; // atualize o estado.
                        update.DiscountApplied = partBudgetByRequest.Quantity >= 3 ? 0.10m : 0; // tera desconto ??.

                        // Adicione o orçamentoPeça ao Banco de dados.
                        await _partsBudget.UpdatePartsBudgetAsync(update); 

                    }
                } // Se false.
                else
                {
                    //Se houver orçamentoPeça finalizado ou liberado para compra adicione a lista de mensagem.
                    messageList.Add($"Orçamento da peça:({partExists.Name}) está Finalizado ou Liberado para Compra.");
                }


            }

            // Caso mensagem contenha uma lista de erro, lançe a exceção com o erro (mesmo sendo um 204).
            if (messageList.Any()) 
            {
                throw new OnExceptionSystem(messageList);
            }

            // Salve a atualização no banco.
            await _save.SaveChangesAsync(); 

        }

        private void Validate(RequestPartBudgetListDTO updatePartBudget)
        {
            //Instancie o validator.
            var validator = new ValidatorPartsBudgetUseCase(); 

            //Valida os dados.
            var result = validator.Validate(updatePartBudget);

            //Se Conter erros.
            if (result.IsValid is false)
            {
                // Agrupa os erros em uma lista.
                var erros = result.Errors.Select(erros => erros.ErrorMessage).ToList();

                // Lance a exceção.
                throw new OnExceptionSystem(erros); 
            }
        }
    }
}
