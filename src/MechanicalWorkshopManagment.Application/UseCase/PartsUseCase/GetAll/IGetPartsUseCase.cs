using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseParts;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.GetAll
{
    /// <summary>
    /// Interface para regra de negócio.
    /// </summary>
   public interface IGetPartsUseCase : IGenericUseCase
    {
        Task<ResponsePartsGetList> GetPartsAllExecute();
    }
}
