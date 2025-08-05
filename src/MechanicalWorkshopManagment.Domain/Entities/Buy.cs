using MechanicalWorkshopManagment.Communication.Enums;

namespace MechanicalWorkshopManagment.Domain.Entities
{ 
    /// <summary>
    /// Entidade no banco de dados (Compras).
    /// </summary>
    public class Buy
    {
        public int Id { get; set; } // ID DA COMPRA.
        public int CustomerId { get; set; } // CHAVE ESTRANGERIA (FK).
        public Customer Customer { get; set; } = null!; // RELACIONAMENTO.

        public int PartsId { get; set; } // ID DA PEÇA.
        public Parts Parts { get; set; } = null!; // PEÇA.

        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS COMPRADAS.
        public decimal CostPrice { get; set; } // PREÇO DE CUSTO.
        public PurchaseStatus PurchaseStatus { get; set; } // STATUS DA COMPRA (CANCELADA, CONCLUIDA).

        public DeliveredStatus StatusDelivered { get; set; } // STATUS DA ENTREGA.
        public decimal? AmountReceivable { get; set; } // VALOR EXCEDENTE DA COMPRA (SE HOUVER).
        public DateTime Date { get; set; } // DATA DA COMPRA.


    }
}
