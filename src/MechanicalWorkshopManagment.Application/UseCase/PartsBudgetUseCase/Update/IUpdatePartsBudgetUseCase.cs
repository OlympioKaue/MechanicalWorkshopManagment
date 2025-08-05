using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Update
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IUpdatePartsBudgetUseCase : IGenericUseCase
    {
        Task UpdatePartsBudgetExecute(RequestPartBudgetListDTO updatePartBudget, int idCustomer);
    }
}
