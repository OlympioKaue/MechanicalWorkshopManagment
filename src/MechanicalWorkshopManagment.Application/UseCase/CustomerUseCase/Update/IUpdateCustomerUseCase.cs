using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Update
{
    /// <summary>
    /// Interface para o caso de uso na regra de negócio.
    /// </summary>
    public interface IUpdateCustomerUseCase : IGenericUseCase
    {
        Task UpdateCustomerExecute(int idCustomer, RequestCustomerDTO updateCustomer);
    }
}
