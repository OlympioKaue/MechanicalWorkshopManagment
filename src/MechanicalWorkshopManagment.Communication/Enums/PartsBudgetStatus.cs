using System.ComponentModel.DataAnnotations;

namespace MechanicalWorkshopManagment.Communication.Enums
{
    /// <summary>
    /// Enum de orçamentoPeça.
    /// </summary>
    public enum PartsBudgetStatus : int
    {
        [Display(Name = "Em Espera")]
        InWaiting = 1, 

        [Display(Name = "Orçamento Finalizado")]
        Finished = 2, 

    }
}
