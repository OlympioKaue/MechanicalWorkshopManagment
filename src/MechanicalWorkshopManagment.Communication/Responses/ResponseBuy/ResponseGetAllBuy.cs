using MechanicalWorkshopManagment.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseBuy
{
    /// <summary>
    /// Classe responsavel pelo retorno das compras feita pelo cliente.
    /// </summary>
    public class ResponseGetAllBuy
    {
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public int QuantityPurchased {get; set; } // QUANTIDADE DE COMPRAS.
     
    }
}
