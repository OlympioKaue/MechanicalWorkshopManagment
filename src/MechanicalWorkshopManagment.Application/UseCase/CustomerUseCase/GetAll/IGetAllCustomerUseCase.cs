using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.GetAll
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IGetAllCustomerUseCase : IGenericUseCase
    {
        Task<ResponseCustomerGetList> GetAllCustomerExecute();
    }
}
