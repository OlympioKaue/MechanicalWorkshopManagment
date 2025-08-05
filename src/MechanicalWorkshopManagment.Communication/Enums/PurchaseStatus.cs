using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Enums
{
    /// <summary>
    /// Enum de estado da compra.
    /// </summary>
    public enum PurchaseStatus : int
    {

        [Display(Name = "Compra Finalizada")]
        Finished = 3,
    }
}
