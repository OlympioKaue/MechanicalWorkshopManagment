using Mapster;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using MechanicalWorkshopManagment.Communication.Responses.ResponseBuy;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.Mapster
{
    /// <summary>
    /// Classe de mapeamento Buy.
    /// </summary>
    public class BuyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
           // POST / UPDATE(ID)
            config.NewConfig<RequestBuyDTO, Buy>();  // REQUEST -> ENTIDADE.
          

            //GET
            config.NewConfig<Buy, ResponseGetAllBuy>() // ENTIDADE -> RESPONSE
                .Map(op => op.ClientName, src => src.Customer.ClientName);
               

            
            
        }
    }
}
