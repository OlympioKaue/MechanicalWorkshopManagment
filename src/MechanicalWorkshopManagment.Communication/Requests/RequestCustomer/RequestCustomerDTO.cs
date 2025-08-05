using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Requests.RequestCustomer
{
    /// <summary>
    /// Request para criar um cliente.
    /// </summary>
    public class RequestCustomerDTO
    {
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public string? VehiclePlate { get; set; } // PLACA DO VEÍCULO.
        public string? CepClient { get; set; } // CEP DO CLIENTE.
    }
}
