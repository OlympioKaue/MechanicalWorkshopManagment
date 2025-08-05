using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Register
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface ICreateCustomerUseCase : IGenericUseCase
    {
        Task<ResponseCustomerCreate> RegistrationCustomerExecute(RequestCustomerDTO createCustomer);
    }
}
