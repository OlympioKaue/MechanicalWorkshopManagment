using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;
using MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Register
{
    /// <summary>
    /// Interface para uso na regra de negócio.
    /// </summary>
    public interface IPartsBudgetUseCase : IGenericUseCase
    {
        Task<ResponsePartsBudgetCreate> RegistrationPartsBudgetExecute(RequestPartBudgetListDTO createPartBudget, int idCustomer);
    }
}
