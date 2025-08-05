using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer
{
    /// <summary>
    /// Classe responsavel por retorna os dados do cliente após registrar.
    /// </summary>
    public class ResponseCustomerCreate
    {
        public int Id { get; set; } // ID DO CLIENTE.
        public string? ClientName { get; set; } // NOME DO CLIENTE.
    }
}
