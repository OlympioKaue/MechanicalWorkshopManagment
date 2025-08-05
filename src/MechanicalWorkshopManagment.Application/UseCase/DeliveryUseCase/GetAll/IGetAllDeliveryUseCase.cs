using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;

namespace MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.GetAll
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IGetAllDeliveryUseCase : IGenericUseCase
    {
        Task<ResponseDeliveryList> GetAllDelivery();
    }
}
