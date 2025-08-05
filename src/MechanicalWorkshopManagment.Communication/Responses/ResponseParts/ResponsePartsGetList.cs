using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseParts
{
    /// <summary>
    /// Agrupamento de list.
    /// </summary>
    public class ResponsePartsGetList
    {
        public List<ResponsePartsGetAll> Parts { get; set; } = []; // LIST DE PEÇAS.
    }
}
