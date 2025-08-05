using MechanicalWorkshopManagment.Application.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Delete
{
    /// <summary>
    /// Interface para uso na regra de negócio.
    /// </summary>
    public interface IDeletePartsUseCase : IGenericUseCase
    {
        Task DeletePartsExecute(int idParts);
    }
}
