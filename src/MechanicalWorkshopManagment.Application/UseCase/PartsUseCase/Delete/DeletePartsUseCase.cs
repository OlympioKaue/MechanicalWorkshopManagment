using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Delete
{
    public class DeletePartsUseCase : IDeletePartsUseCase
    {
        private readonly IParts _parts;
        private readonly ISaveChangesWorks _save;

        public DeletePartsUseCase(IParts parts,ISaveChangesWorks save)
        {
            _parts = parts;
            _save = save;
        }

        public async Task DeletePartsExecute(int idParts)
        {
            // Existe essa peça vinculado a esse id ?.
            var partsExists = await _parts.ThisPartsExistsWithID(idParts); 
            if (partsExists is null)
                // Exceção 404 
                throw new NotFoundException($"A peça informada com id({idParts}) não existe no sistema.");


            // Deleta a peça do sistema, não precisa retorna nada.
            _parts.DeletePart(partsExists);


            // Salva as alterações no banco de dados.
            await _save.SaveChangesAsync(); 


        }
    }
}
