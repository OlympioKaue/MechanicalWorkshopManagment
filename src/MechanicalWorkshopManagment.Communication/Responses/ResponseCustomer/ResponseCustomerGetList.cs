using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer
{
    /// <summary>
    /// Classe que agrupa os clientes em uma List.
    /// </summary>
    public class ResponseCustomerGetList
    {
        public List<ResponseCustomerCreate> Customers { get; set; } = []; // LIST DE CLIENTES.
    }
}
