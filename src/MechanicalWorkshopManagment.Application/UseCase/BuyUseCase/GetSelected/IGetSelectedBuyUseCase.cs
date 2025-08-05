using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetSelected
{
    /// <summary>
    /// Interface para o uso na regra de negócio.
    /// </summary>
    public interface IGetSelectedBuyUseCase : IGenericUseCase
    {
        Task<List<ResponseSelectedBuy>> GetSelectedBuyExecute(int idCustomer);

    }
}
