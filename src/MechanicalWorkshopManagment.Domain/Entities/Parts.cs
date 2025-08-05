using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Entities
{ 
    /// <summary>
    /// Entidade do banco de dados (Parts).
    /// </summary>
   public class Parts
    {
        public int Id { get; set; } // ID DA PEÇA.
        public string? Name { get; set; } // NOME DA PEÇA.
        public decimal Price { get; set; } // PREÇO DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS.

       public List<PartsBudget> PartsBudget { get; set; } = []; // RELACIONAMENTO ENTRE O ORÇAMENTOPEÇAS.
    }
}
