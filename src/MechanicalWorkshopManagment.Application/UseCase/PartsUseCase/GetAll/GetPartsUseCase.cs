using Mapster;
using MechanicalWorkshopManagment.Application.Mapster;
using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Exception.BaseException;
using System.Reflection.Metadata;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetAll
{
    public class GetPartsUseCase : IGetPartsUseCase
    {
        private readonly IParts _parts;

        public GetPartsUseCase(IParts parts)
        {
            _parts = parts;
        }

        public async Task<ResponsePartsGetList> GetPartsAllExecute()
        {
            // Obter todas as peças cadastradas no sistema.
            var getPartsAll = await _parts.GetPartsAllAsync(); 
            if (getPartsAll.Count is 0)
                // Exceção 404.
                throw new NotFoundException("Nenhuma peça encontrada no sistema."); 

            //Retorne a resposta da entidade.
            var response = getPartsAll.Adapt<List<ResponsePartsGetAll>>();

            //Retorne a resposta para o usuário.
            return new ResponsePartsGetList
            {
                Parts = response
            };


        }
    }
}
