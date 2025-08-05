using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery
{
    /// <summary>
    /// Classe responsável por retorna o nome e quantidade de entregas realizadas.
    /// </summary>
    public class ResponseDeliveryList
    {
        public List<ResponseDeliveryAll> Deliverys { get; set; } = []; // LIST DE ENTREGAS.
    }
}
