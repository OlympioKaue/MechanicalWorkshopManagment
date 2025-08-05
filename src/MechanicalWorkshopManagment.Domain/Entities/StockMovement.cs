using MechanicalWorkshopManagment.Communication.Enums;

namespace MechanicalWorkshopManagment.Domain.Entities
{
    /// <summary>
    /// Entidade do banco de dados (StockMovement).
    /// </summary>
    public class StockMovement
    {
        public int Id { get; set; } // ID DA MOVIMENTAÇÃO DO ESTOQUE.
        
        public int PartsId { get; set; } // ID DA PEÇA.
        public Parts Parts { get; set; } = null!; // RELACIONAMENTO.

        public MovementsStatus Movements { get; set; } // MOVIMENTOS DO ESTOQUE (ENUM).
        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS RETIRADAS DO ESTOQUE.
        public DateTime Date { get; set; } // DATA DA SAIDA OU ENTRADA.
    }
}
