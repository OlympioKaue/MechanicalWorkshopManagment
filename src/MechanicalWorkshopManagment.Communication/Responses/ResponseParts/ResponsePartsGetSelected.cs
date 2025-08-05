using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseParts
{
    /// <summary>
    /// Classe responsável por retorna os dados da peça.
    /// </summary>
    public class ResponsePartsGetSelected
    {
        public int Id { get; set; } // ID DA PEÇA.
        public string? Name { get; set; } // NOME DA PEÇA.
        public decimal Price { get; set; } // PREÇO DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE DA PEÇA.
    }
}
