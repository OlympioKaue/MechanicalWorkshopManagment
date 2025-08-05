using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetSelected
{
    /// <summary>
    /// Interface para o caso de uso de obter uma peça selecionada.
    /// </summary>
    public interface IGetPartsSelectedUseCase : IGenericUseCase
    {
        Task<ResponsePartsGetSelected> GetPartsSelectedExecute(int idParts);
    }
}
