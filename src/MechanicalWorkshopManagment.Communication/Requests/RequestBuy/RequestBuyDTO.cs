using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Requests.RequestBuy
{
    /// <summary>
    /// Requisição para registrar a compra de peças (Preço de Custo).
    /// </summary>
    public class RequestBuyDTO
    {
        public decimal CostPrice { get; set; } // PREÇO PAGO PELO CLIENTE.    
    }
}
