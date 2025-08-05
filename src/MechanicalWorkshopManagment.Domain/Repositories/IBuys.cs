using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IBuys
    {
        /// <summary>
        /// Adiciona uma compra ao banco de dados.
        /// </summary>
        /// <param name="createBuy"></param>
        /// <returns></returns>
        Task AddBuys(Buy createBuy); 



        /// <summary>
        /// Retorna uma lista de compras, filtrando apenas as compras finalizadas.
        /// </summary>
        /// <returns></returns>
        Task<List<Buy>> GetBuys();


        /// <summary>
        /// Retorne uma compra vinculada ao id do cliente.
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Task<List<Buy>> GetPartsBudgetByBuyCustomer(int idCustomer);




    }
}
