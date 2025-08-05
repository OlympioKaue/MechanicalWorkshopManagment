using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetSelected
{
    /// <summary>
    /// Interface para o caso de uso na regra de negócio.
    /// </summary>
    public interface IGetSelectedCustomerUseCase : IGenericUseCase
    {
        Task<ResponseSelectedCustomer> GetSelectedCustomerExecute(int idCustomer);
    }
}
