using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseParts
{
    /// <summary>
    /// Obter todas as peças em list.
    /// </summary>
   public class ResponsePartsGetAll
    {
        public int Id { get; set; } // ID DA PEÇA.
        public string? Name { get; set; } // NOME DA PEÇA.
       

    }
}
