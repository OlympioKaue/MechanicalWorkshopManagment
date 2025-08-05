using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Entities
{
    /// <summary>
    /// Entidade no banco de dados (Cliente).
    /// </summary>
    public class Customer
    {
        public int Id { get; set; } // ID DO CLIENTE.
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public string? VehiclePlate { get; set; } // PLACA DO VEÍCULO.
        public string? CepClient { get; set; } // CEP DO CLIENTE.
        public List<PartsBudget> PartsBudget { get; set; } = []; // RELACIONAMENTO ENTRE O ORÇAMENTOPEÇA.
      

    }
}
