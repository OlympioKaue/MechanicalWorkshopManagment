using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface ISaveChangesWorks 
    {
        /// <summary>
        /// Salve as alterações no banco de dados.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
