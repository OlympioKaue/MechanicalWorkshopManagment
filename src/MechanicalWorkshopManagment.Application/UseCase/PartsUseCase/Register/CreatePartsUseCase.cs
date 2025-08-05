using Mapster;
using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Register
{
    public class CreatePartsUseCase : ICreatePartsUseCase
    {
        private readonly IParts _parts;
        private readonly IStockMovements _movements;
        private readonly ISaveChangesWorks _save;

        public CreatePartsUseCase(IParts parts, IStockMovements movements, ISaveChangesWorks save)
        {
            _parts = parts;
            _movements = movements;
            _save = save;
        }

        public async Task<ResponsePartsCreate> RegistrationPartsExecute(RequestPartDTO createParts)
        {
            // Valida os dados da request.
            Validate(createParts);

            // Mapeia o DTO para a entidade Parts.
            var partsMapping = createParts.Adapt<Parts>();

            // Existe essa peça com o mesmo nome no sistema?
            var thePartsExists = await _parts.ThePartsNameExists(partsMapping.Name!); 
            if (thePartsExists is true)
                // Exceção 409.
                throw new ExceptionConflict("Já existe uma peça registrada com este nome no sistema.");


            // Adiciona a nova peça no sistema e salve para gerar o id da peça e evitar erro ao registrar a movimentação no estoque.
            await _parts.AddPartAsync(partsMapping); 


            //Adicione a movimentação do estoque.
            var addMovements = new StockMovement
            {
                PartsId = partsMapping.Id, // id da peça.
                Quantity = partsMapping.Quantity, // quantidade de peças a serem registradas.
                Date = DateTime.UtcNow, // data do movimento de estoque.
                Movements = MovementsStatus.Entry // tipo de movimento: Entrada.
            };

            // Adicione o movimento de estoque.
            await _movements.AddStockMovementAsync(addMovements);

            // Salve o movimento de estoque.
            await _save.SaveChangesAsync(); 

            //Retorno do mapeamento da entidade para o DTO.
            var response = partsMapping.Adapt<ResponsePartsCreate>();

            // Definindo o movimento como Entrada.
            response.Movements = MovementsStatus.Entry.ToString();

            // Retorna a resposta para o usuário
            return response; 


        }

        /// <summary>
        /// Valida os registro das peças.
        /// </summary>
        /// <param name="createParts">Parâmetro via request</param>
        /// <exception cref="ExceptionConflict"></exception>
        /// <exception cref="OnExceptionSystem"></exception>
        private void Validate(RequestPartDTO createParts)
        {
            //Instacie o validator.
            var validation = new Validator.ValidatorPartsUseCase();

            //Valide os dados.
            var resultValidation = validation.Validate(createParts);

            //Se conter erros.
            if (resultValidation.IsValid is false)
            {
                // Agrupe os erros em uma lista.
                var errors = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

                // Lançamento de exceção.
                throw new OnExceptionSystem(errors); 
            }
        }
    }
}
