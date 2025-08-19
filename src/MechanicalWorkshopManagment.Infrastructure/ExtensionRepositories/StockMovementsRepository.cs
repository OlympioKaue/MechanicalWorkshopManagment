using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
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

        public async Task<List<StockMovement>> GetByStockMovements(DateTime dateMonth, DateTime dateYear)
        {

            return await _dbContext
           .StockMovements
           .AsNoTracking()
           .Include(x => x.Parts)
           .Where(
           stock =>
           stock.Date.Month >= dateMonth.Month &&
           stock.Date.Year <= dateYear.Date.Year)
           .OrderBy(stock => stock.Date)
           .ThenBy(stock => stock.Id)
           .ToListAsync();


        }
    }
}
