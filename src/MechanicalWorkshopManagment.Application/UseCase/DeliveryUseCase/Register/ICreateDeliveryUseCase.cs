using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery;

namespace MechanicalWorkshopManagment.Application.UseCase.DeliveryUseCase.Register
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface ICreateDeliveryUseCase : IGenericUseCase
    {
        public Task<ResponseDeliveryCreate> RegistrationDeliveryExecute(int idCustomer);
    }
}
