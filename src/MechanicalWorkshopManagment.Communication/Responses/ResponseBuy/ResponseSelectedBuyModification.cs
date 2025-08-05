using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseBuy
{
    /// <summary>
    /// Classe responsável por retorna para o usuário.
    /// </summary>
    public class ResponseSelectedBuyModification
    {
        public string? PartsName { get; set; } // NOME DA PEÇA.
        public int QuantityParts { get; set; } // QUANTIDADE DE PEÇAS.
        public decimal DiscountApplied { get; set; } // DESCONTO APLICADO EM VALOR.
    }
}
