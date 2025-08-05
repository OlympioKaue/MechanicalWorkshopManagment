using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetSelected
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IGetSelectedPartsBudgetUseCase : IGenericUseCase
    {
        Task<ResponseSelectedListPartsBudget> GetSelectedPartsBudgetExecute(int idCustomer);
    }
}
