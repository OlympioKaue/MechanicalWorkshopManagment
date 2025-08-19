using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IStockMovements
    {
        /// <summary>
        /// Adiciona a entrada ou saida na movimentação do estoque.
        /// </summary>
        /// <param name="addStockMovement"></param>
        /// <returns></returns>
        Task AddStockMovementAsync(StockMovement addStockMovement);

        /// <summary>
        /// Retorne a lista da movimentação no estoque de acordo com o mês e ano.
        /// </summary>
        /// <param name="dateMonth"></param>
        /// <returns></returns>
        Task<List<StockMovement>> GetByStockMovements(DateTime dateMonth, DateTime dateYear);
    }
}
