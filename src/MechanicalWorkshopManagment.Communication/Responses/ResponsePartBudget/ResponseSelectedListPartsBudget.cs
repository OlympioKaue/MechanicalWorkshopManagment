using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget
{
    /// <summary>
    /// Classe responsável por selecionar o retorno de resposta para o cliente.
    /// </summary>
    public class ResponseSelectedListPartsBudget
    {
        public List<ResponseSelectedPartsBudget> PartsBudgetSelected { get; set; } = []; // LIST DE ORÇAMENTOPEÇA.
        
    }
}
