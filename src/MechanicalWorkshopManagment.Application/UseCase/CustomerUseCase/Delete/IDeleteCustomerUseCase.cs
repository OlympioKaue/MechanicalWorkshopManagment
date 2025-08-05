using MechanicalWorkshopManagment.Application.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Delete
{
    /// <summary>
    /// Interface para o caso de uso na regra de negócio.
    /// </summary>
    public interface IDeleteCustomerUseCase : IGenericUseCase
    {
        Task DeleteCustomerExecute(int idCustomer);
    }
}
