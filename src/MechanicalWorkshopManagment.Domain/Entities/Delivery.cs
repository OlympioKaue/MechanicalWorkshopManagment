using MechanicalWorkshopManagment.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Entities
{
    /// <summary>
    /// Entidade no banco de dados (Entregas).
    /// </summary>
    public class Delivery
    { 
        public int Id { get; set; } // ID DA ENTREGA.
        public int CustomerId { get; set; } // CHAVE ESTRANGERIA (FK).
        public Customer Customer { get; set; } = null!; // RELACIONAMENTO.

        public string? CepClient { get; set; }  // CEP DO CLIENTE.
        public string? AddressClient { get; set; } // ENDEREÇO DO CLIENTE.
        public int QuantityDelivered { get; set; } // QUANTIDADE DE ENTREGAS.
    }
}
