using MechanicalWorkshopManagment.Communication.Enums;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget
{
    /// <summary>
    /// Retorne dados completos sobre orçamentoPeça do cliente específico.
    /// </summary>
    public class ResponseSelectedPartsBudget
    {
        public int Id { get; set; } // ID DO ORÇAMENTO DE PEÇAS.
        public int CustomerId { get; set; } // ID DO CLIENTE COMPRADOR.
        public int PartsId { get; set; } // ID DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE ORÇADA.
        public PartsBudgetStatus BudgetStatus { get; set; } // ESTADO DA COMPRA.
        public decimal TotalPrice { get; set; } // PREÇO TOTAL.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public decimal DiscountApplied { get; set; } // DESCONTO APLICADO EM VALOR.

    }
}
