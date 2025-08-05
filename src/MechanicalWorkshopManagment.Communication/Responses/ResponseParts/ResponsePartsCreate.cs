using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseParts
{
    /// <summary>
    /// Retorno dos registros das peças.
    /// </summary>
    public class ResponsePartsCreate
    {
        public int Id { get; set; } // ID DA PEÇA.
        public string? Name { get; set; } // NOME DA PEÇA.
        public int Quantity { get; set; } // QUANTIDADE DE PEÇAS.
        public string? Movements { get; set; } // TIPO DE MOVIMENTO (ENTRADA OU SAÍDA).

    }
}
