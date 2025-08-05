using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget
{
    /// <summary>
    /// Request para enviar os dados pelo cliente.
    /// </summary>
    public class RequestPartBudgetDTO
    {
        public int PartsId { get; set; } // ID DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS.
    }
}
