using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Infrastructure.ExtensionRepositories
{
    /// <summary>
    /// Classe que herda interfaces do tipo (StockMovements).
    /// </summary>
    internal class StockMovementsRepository : IStockMovements
    {

        private readonly MechanicalManagmentDbContext _dbContext;

        public StockMovementsRepository(MechanicalManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddStockMovementAsync(StockMovement addMovements)
        {
            await _dbContext.StockMovements.AddAsync(addMovements);

        }
    }
}
