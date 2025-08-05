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
    /// Enum de movementos no estoque.
    /// </summary>
    public enum MovementsStatus : int
    {
       
        [Display(Name = "Entrada")]
        Entry = 1, 

        [Display(Name = "Saida")]
        Exit = 2, 



    }
}
