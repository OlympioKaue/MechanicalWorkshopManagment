using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseBuy
{
    /// <summary>
    /// Classe responsável por mostrar a compra do cliente.
    /// </summary>
    public class ResponseSelectedBuy
    {
        public int Id { get; set; } // ID COMPRA.
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public DateTime DatePurchase { get; set; } // DATA DA COMPRA.
        public List<ResponseSelectedBuyModification> PurchasedItems { get; set; } = []; // LIST PARA ITENS COMPRADOS.
    

    }
}
