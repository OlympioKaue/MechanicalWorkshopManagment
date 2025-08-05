using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Enums
{
    /// <summary>
    /// Enum de status da entrega.
    /// </summary>
    public enum DeliveredStatus : int
    {
        [Display(Name ="Em espera")]
        InWaiting = 1,

        [Display(Name = "Finalizada")]
        Finished = 2,
    }
}
