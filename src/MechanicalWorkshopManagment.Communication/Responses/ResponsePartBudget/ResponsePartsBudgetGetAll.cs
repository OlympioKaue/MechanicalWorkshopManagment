using MechanicalWorkshopManagment.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget
{
    /// <summary>
    /// Retorne os dados do orçamentoPeça para o usuário.
    /// </summary>
    public class ResponsePartsBudgetGetAll
    {
        public int Id { get; set; } // ID DO ORÇAMENTO DE PEÇAS.
        public int PartsId { get; set; } // ID DA PEÇA.
        public string? ClientName { get; set; } // NOME DO CLIENTE.
        public PartsBudgetStatus BudgetStatus { get; set; } // ESTADO DA COMPRA.
       

    }
}
