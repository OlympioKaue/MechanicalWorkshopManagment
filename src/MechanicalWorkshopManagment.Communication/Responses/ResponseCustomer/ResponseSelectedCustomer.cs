using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseCustomer
{
    /// <summary>
    /// Retorne a resposta de um cliente selecionado.
    /// </summary>
    public class ResponseSelectedCustomer
    {
        public int Id { get; set; } // ID DO CLIENTE.
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public string? VehiclePlate { get; set; } // PLACA DO VEÍCULO.
        public string? CepClient { get; set; } // CEP DO CLIENTE.
    }
}
