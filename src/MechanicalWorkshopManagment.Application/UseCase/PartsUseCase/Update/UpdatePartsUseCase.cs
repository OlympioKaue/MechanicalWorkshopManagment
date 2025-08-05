using Mapster;
using MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Validator;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Update
{
    public class UpdatePartsUseCase : IUpdatePartsUseCase
    {
        private readonly IParts _parts;
        private readonly ISaveChangesWorks _save;

        public UpdatePartsUseCase(IParts parts, ISaveChangesWorks save)
        {
            _parts = parts;
            _save = save;
        }


        public async Task UpdatePartsExecute(RequestPartDTO updateParts, int idParts)
        {
            // Valida os dados da request.
            Validate(updateParts);


            // Existe essa peça no sistema ?, antes de atualizar verifique.
            var thePartsExists = await _parts.ThisPartsExistsWithID(idParts); 
            if (thePartsExists is null)
                // Exceção 404.
                throw new NotFoundException($"A peça informada com id({idParts}) não existe no sistema.");


            // Mapeia os dados da request para a entidade Parts.
            var partsUpdateMapping = updateParts.Adapt(thePartsExists); 

            //Atualize a peça no sistema, não retorne nada.
            _parts.UpdatePart(partsUpdateMapping);


            // Salva as alterações no banco de dados.
            await _save.SaveChangesAsync(); 



        }
        /// <summary>
        /// Valida os registro das peças.
        /// </summary>
        /// <param name="update">Parâmetro via request</param>
        /// <exception cref="ExceptionConflict"></exception>
        /// <exception cref="OnExceptionSystem"></exception>
        private void Validate(RequestPartDTO updateParts)
        {
            //Instancie o validator.
            var validation = new ValidatorPartsUseCase();

            //Valide os dados.
            var result = validation.Validate(updateParts);

            //Se conter erros.
            if (result.IsValid is false)
            {
                // Agrupa os erros em uma lista.
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                // Lançamento de exceção.
                throw new OnExceptionSystem(errors); 
            }
        }
    }
}
