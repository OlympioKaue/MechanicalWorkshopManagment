using MechanicalWorkshopManagment.Communication.Enums;
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
    /// Classe que herda interfaces do tipo (Buy).
    /// </summary>
    public class BuyRepository : IBuys
    {

        private readonly MechanicalManagmentDbContext _dbContext;

        public BuyRepository(MechanicalManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBuys(Buy buy)
        { 
            await _dbContext.Buy.AddAsync(buy);
        }


        public async Task<List<Buy>> GetPartsBudgetByBuyCustomer(int idCustomer)
        {
            return await _dbContext.Buy
                .Include(src => src.Customer)
                .Where(src => src.CustomerId == idCustomer &&
                       src.StatusDelivered == Communication.Enums.DeliveredStatus.InWaiting)
                .ToListAsync();
        }



        public async Task<List<Buy>> GetBuys()
        {

            return await _dbContext.Buy
                .Where(x => x.Parts.PartsBudget.Any(x => x.BudgetStatus == PartsBudgetStatus.Finished))
                .Include(x => x.Customer)
                .Include(x => x.Parts.PartsBudget) 
                .OrderBy(t => t.Id)
                .ToListAsync();

        }


    }
}