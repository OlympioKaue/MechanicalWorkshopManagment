using MechanicalWorkshopManagment.Communication.Enums;

namespace MechanicalWorkshopManagment.Domain.Entities
{
    /// <summary>
    /// Entidade do banco de dados (PartsBudget).
    /// </summary>
    public class PartsBudget
    {
        public int Id { get; set; } // ID DO ORÇAMENTO DE PEÇAS.
        public int CustomerId { get; set; } // CHAVE ESTRANGERIA (FK).
        public Customer Customer { get; set; } = null!; // RELACIONAMENTO.

        public int PartsId { get; set; } // ID DA PEÇA.
        public Parts Parts { get; set; } = null!; // RELACIONAMENTO.

        public DateTime DatePartsBudget { get; set; } // DATA DO ORÇAMENTO.
        public int Quantity { get; set; }
        public PartsBudgetStatus BudgetStatus { get; set; } // ESTADO DA COMPRA.
        public decimal AppliedPrice { get; set; } // PREÇO APLICADO.
        public decimal TotalPrice { get; set; } // PREÇO TOTAL.
        public decimal DiscountApplied { get; set; } // DESCONTO APLICADO EM VALOR.

    }
}
