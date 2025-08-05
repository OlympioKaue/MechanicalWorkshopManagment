using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.GetAll
{
    /// <summary>
    /// Interface de uso para regra de negócio.
    /// </summary>
    public interface IGetAllPartsBudgetsUseCase : IGenericUseCase
    {
        Task<ResponsePartsBudgetList> GetAllPartsBudgetExecute();
    }
}
