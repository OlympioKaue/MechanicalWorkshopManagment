using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget
{
    /// <summary>
    /// Classe responsável pelo retorno de uma lista de orçamentoPeça.
    /// </summary>
    public class ResponsePartsBudgetList
    {
        public List<ResponsePartsBudgetGetAll> partsBudget { get; set; } = []; // LIST DE ORÇAMENTOPEÇA;
    }
}
