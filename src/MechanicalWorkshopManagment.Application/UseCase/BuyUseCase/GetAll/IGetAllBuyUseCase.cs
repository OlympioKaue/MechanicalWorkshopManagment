using MechanicalWorkshopManagment.Application.Reflection;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.GetAll
{
    /// <summary>
    /// Interface de uso para regra de negócio.
    /// </summary>
    public interface IGetAllBuyUseCase : IGenericUseCase
    {
        Task<ResponseBuyList> GetAllBuyExecute();
    }
}
