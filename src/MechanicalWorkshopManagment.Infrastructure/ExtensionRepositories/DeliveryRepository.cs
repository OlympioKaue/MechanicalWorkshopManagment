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
    /// Classe que herda interfaces do tipo (Delivery).
    /// </summary>
    internal class DeliveryRepository : IDelivery
    {

        private readonly MechanicalManagmentDbContext _dbContext;


        public DeliveryRepository(MechanicalManagmentDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
  
            await _dbContext.Delivery.AddAsync(delivery);
        }

        public async Task<List<Delivery>> GetDelivery()
        {
            return await _dbContext.Delivery.Include(src => src.Customer).ToListAsync();
        }

        public async Task<Delivery?> GetDeliveryByBudgetId(int idCustomer)
        {
            
            return await _dbContext.Delivery
                .FirstOrDefaultAsync(src => src.CustomerId == idCustomer);
        }


       
    }
}
