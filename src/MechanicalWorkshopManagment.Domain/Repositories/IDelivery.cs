using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IDelivery
    {
        /// <summary>
        /// Adiciona uma entrega ao banco de dados.
        /// </summary>
        /// <param name="createDelivery"></param>
        /// <returns></returns>
        Task AddDeliveryAsync(Delivery createDelivery);



        /// <summary>
        /// Verificar se ja existe uma entrega vinculada ao id cadastrado no banco de dados.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<Delivery?> GetDeliveryByBudgetId(int idCustomer);



        /// <summary>
        /// Retorne uma lista de entregas.
        /// </summary>
        /// <returns></returns>
        Task<List<Delivery>> GetDelivery();

    }
}
