using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseDelivery
{
    /// <summary>
    /// Classe responsável por retorna o nome do cliente e quantidade de entregas realizadas.
    /// </summary>
    public class ResponseDeliveryAll
    {
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public int QuantityDelivered { get; set; } // QUANTIDADE DE ENTREGAS.
    }
}
