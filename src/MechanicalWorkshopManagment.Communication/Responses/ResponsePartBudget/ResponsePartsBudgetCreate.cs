using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MechanicalWorkshopManagment.Communication.Enums;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponsePartBudget
{
    /// <summary>
    /// Retorno da criação de orçamentoPeças.
    /// </summary>
    public class ResponsePartsBudgetCreate
    {
        public string? Message { get; set; } // MENSAGEM PARA O USUÁRIO.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public bool PecaInexistente { get; set; } // INDICA SE HOUVE PEÇA INEXISTENTE NO ORÇAMENTO.

        public PartsBudgetStatus StateMessanger { get; set; } // ESTADO DA COMPRA.

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] 
        public decimal TotalPrice { get; set; } // PREÇO TOTAL DO ORÇAMENTO DE PEÇAS.

    }
}
