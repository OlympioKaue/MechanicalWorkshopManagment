using MechanicalWorkshopManagment.Application.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Delete
{
    /// <summary>
    /// Interface de uso para regra de negócio.
    /// </summary>
    public interface IDeletePartsBudgetUseCase : IGenericUseCase
    {
        Task DeletePartsBudgetExecute(int idCustomer);
    }
}
