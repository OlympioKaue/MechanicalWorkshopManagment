using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseBuy
{
    /// <summary>
    /// Retorno da compra de peças.
    /// </summary>
    public class ResponseBuyCreate
    {

        public int Id { get; set; } // ID DA COMPRA.
        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS COMPRADAS.
        public DateTime Date { get; set; } // DATA DA COMPRA.
        public decimal AmountReceivable { get; set; } // VALOR EXCEDENTE DA COMPRA.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public string? Movements { get; set; } // TIPO DE MOVIMENTO (ENTRADA OU SAÍDA).


    }
}
