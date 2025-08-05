using Mapster;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetSelected
{
    public class GetPartsSelectedUseCase : IGetPartsSelectedUseCase
    {
        private readonly IParts _parts;

        public GetPartsSelectedUseCase(IParts parts)
        {
            _parts = parts;
        }

        public async Task<ResponsePartsGetSelected> GetPartsSelectedExecute(int idParts)
        {
            // Existe peças vinculadas a esse id ?.
            var getPartsSelected = await _parts.GetPartsByIdAsync(idParts); 
            if (getPartsSelected is null)
                // Exceção 404.
                throw new NotFoundException($"Peça com ID({idParts}) não encontrada no sistema."); 

            //Retorne para o usuário.
            return getPartsSelected.Adapt<ResponsePartsGetSelected>(); 
        }
    }
}
