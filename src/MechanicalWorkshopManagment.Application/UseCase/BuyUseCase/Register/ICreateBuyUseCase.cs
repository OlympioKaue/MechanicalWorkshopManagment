using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Register
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface ICreateBuyUseCase : IGenericUseCase
    {
        Task<List<ResponseBuyCreate>> RegistrationBuyExecute(RequestBuyDTO createBuy, int idCustomer);
    }
}
