namespace MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget
{
    /// <summary>
    /// Classe com finalidade de receber +1 peça e quantidade para o orçamento do cliente.
    /// </summary>
    public class RequestPartBudgetListDTO
    {
        public List<RequestPartBudgetDTO> partBudget { get; set; } = []; // LIST DE ORÇAMENTOPEÇA.

    }
}
