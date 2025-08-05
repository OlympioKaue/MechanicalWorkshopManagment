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
    }
}
