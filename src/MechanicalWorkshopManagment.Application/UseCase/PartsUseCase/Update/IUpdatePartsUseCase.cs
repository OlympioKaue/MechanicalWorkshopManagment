using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Update
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IUpdatePartsUseCase : IGenericUseCase
    {
        Task UpdatePartsExecute(RequestPartDTO updateParts, int idParts);
    }
}
