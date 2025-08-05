using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Requests.RequestParts
{
    /// <summary>
    /// Request de registro de peças.
    /// </summary>
   public class RequestPartDTO
    {
        public string? Name { get; set; } // NOME DA PEÇA.
        public decimal Price { get; set; } // PREÇO DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE DA PEÇA.
    }
}
