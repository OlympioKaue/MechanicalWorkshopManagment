using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseBuy
{
    /// <summary>
    /// Retorne a lista de compras em list.
    /// </summary>
    public class ResponseBuyList
    {
        public List<ResponseGetAllBuy> Buys { get; set; } = []; // LIST DE COMPRAS.


    }
}
