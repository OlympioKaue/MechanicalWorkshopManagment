using MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;


namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Register
{
    public class PartsBudgetUseCase : IPartsBudgetUseCase
    {
        private readonly ICustomer _customer;
        private readonly IPartsBudgets _partsBudget;
        private readonly IParts _parts;
        private readonly ISaveChangesWorks _save;


        public PartsBudgetUseCase(ICustomer customer, IPartsBudgets partsBudget, IParts parts, ISaveChangesWorks save)
        {
            _customer = customer;
            _partsBudget = partsBudget;
            _parts = parts;
            _save = save;
        }

        public async Task<ResponsePartsBudgetCreate> RegistrationPartsBudgetExecute(RequestPartBudgetListDTO createPartBudget, int idCustomer)
        {

            //Valida os dados de entrada.
            Validate(createPartBudget);

            //Verifica se o cliente existe com o ID fornecido.
            var thisCustomerExists = await _customer.GetCustomerByFirstOrDefaultID(idCustomer); 
            if (thisCustomerExists is null)
                // Exceção 404.
                throw new NotFoundException($"Cliente com o Id:({idCustomer}) não Encontrado.");


            var partBudgetPeding = thisCustomerExists.PartsBudget
                .Any(s => s.BudgetStatus != PartsBudgetStatus.Finished);
            if (partBudgetPeding is true)
                //Exceção 400.
                throw new OnExceptionSystem("O cliente possui orçamentos pendentes, verifique com o vendedor.");

            //Lista para armazenar mensagens de exceção ou sucesso.
            var message = new List<string>();

            //Data Atual do orçamento.
            var currentDate = DateTime.UtcNow;

            //Acumulador para o preço total de todas as peças, Incialmente com 0.
            var TotalAccumulatorPrice = 0; 


            //Loop para cada peça no orçamentoPeça.
            foreach (var partBudget in createPartBudget.partBudget)
            {

                //Verifica se a peça existe com o ID fornecido via Request.
                var thePartsExists = await _parts.ThisPartsExistsWithID(partBudget.PartsId);
                if (thePartsExists is null)
                    //Exceção 404.
                    throw new NotFoundException($"Peça com Id:({partBudget.PartsId}) não encontrado.");


                //Quantidade disponível da peça no estoque.
                var quantityOfPartsAvailable = thePartsExists.Quantity;


                //Valida quantidade disponível.
                if (partBudget.Quantity > quantityOfPartsAvailable)
                {
                    // Se a quantidade for > que disponível adiciona a mensagem na lista.
                    message.Add($"Peça:({thePartsExists.Name}) Indisponível, liberado para compra.");
                    continue; // Pule o loop.

                }

                //Preço original da peça.
                var originalPrice = thePartsExists.Price;

                //Preço com desconto, inicialmente igual ao original.
                var discountedPrice = originalPrice; 

                //Quantidade solicita >= 3, gere desconto na peça solicitada.
                if (partBudget.Quantity >= 3)
                    discountedPrice = originalPrice * 0.9m; // Desconto de 10%.

                //Preço total com desconto aplicado.
                var totalPrice = discountedPrice * partBudget.Quantity;

                //Acumula o preço total para todas as peças.
                TotalAccumulatorPrice += (int)totalPrice; 

                var addPartsBudget = new PartsBudget
                {

                    CustomerId = idCustomer, // id do cliente que está criando o orçamentoPeça.
                    PartsId = partBudget.PartsId, // id da peça que está sendo adicionada ao orçamento.
                    Quantity = partBudget.Quantity, // quantidade da peça.
                    BudgetStatus = PartsBudgetStatus.InWaiting, // estado inicial em espera.
                    DatePartsBudget = currentDate, // data do orçamento.
                    AppliedPrice = discountedPrice, // preço aplicado com desconto, se houver.
                    TotalPrice = totalPrice, // preço total da peça com a quantidade e desconto aplicado.
                    DiscountApplied = partBudget.Quantity >= 3 ? 0.10m : 0, // desconto aplicado, 10% se a quantidade for maior ou igual a 3, caso contrário 0.

                };

                //Adicione o orçamentoPeça ao Banco de dados.
                await _partsBudget.AddPartsBudgetAsync(addPartsBudget);

            }

            //Salva as alterações no banco de dados.
            await _save.SaveChangesAsync();


            //Retorne a mensagem para o usuário.
            return new ResponsePartsBudgetCreate
            {
                //Se a mensagem for > 0, mostre as peças com exceções, caso contrário, todas as peças foram adicionadas com sucesso.
                Message = message.Count > 0
                ? $"Peças adicionadas com exceções: {string.Join(" | ", message)}"
                : "Todas as peças foram adicionadas com sucesso.",

                //Indica se houve peças inexistentes no orçamentoPeça, inicialmente falso.
                PecaInexistente = false,

                //Se mensagem > 0 peça liberada para compra, caso contrário, estado de sucesso.
                StateMessanger = message.Count > 0 ? PartsBudgetStatus.Finished : PartsBudgetStatus.InWaiting
                     //? PartsBudgetStatus.ReleasedForPurchase
                     ,

                //Preço total acumulado de todas as peças adicionadas.
                TotalPrice = TotalAccumulatorPrice


            };

        }

        private void Validate(RequestPartBudgetListDTO createPartBudget)
        {
            //Instancie o validator.
            var validation = new ValidatorPartsBudgetUseCase();

            //Valide os dados.
            var resultValidation = validation.Validate(createPartBudget);

            //Se conter erros.
            if (resultValidation.IsValid is false)
            {
                //Agrupa os erros de validação em uma lista de strings.
                var erros = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

                //Lança a exceção.
                throw new OnExceptionSystem(erros); 
            }
        }
    }
}
