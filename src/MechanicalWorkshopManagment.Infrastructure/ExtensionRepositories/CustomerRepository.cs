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
    /// Classe que herda interfaces do tipo (Customer).
    /// </summary>
    internal class CustomerRepository : ICustomer
    {
        private readonly MechanicalManagmentDbContext _dbContext;

        public CustomerRepository(MechanicalManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task AddCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public void UpdateCustomer(Customer updateCustomer)
        {
           _dbContext.Update(updateCustomer);
        }
        

        public async Task<List<Customer>> ThisCustomerExists()
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .OrderBy(src => src.Id)
                .ToListAsync();
                
        }

        public async Task<bool?> GetCustomerByAnyId(int idCustomer)
        {
            return await _dbContext.Customers.AsNoTracking()
              .AnyAsync(src => src.Id == idCustomer);
        }

      
        public async Task<Customer?> GetCustomerByFirstOrDefaultID(int idCustomer)
        {
            return await _dbContext.Customers
                .Include(src => src.PartsBudget)
                .ThenInclude(src => src.Parts)
              .FirstOrDefaultAsync(src => src.Id == idCustomer);
        }

        public void DeleteCustomer(Customer deleteCustomer)
        {
            _dbContext.Customers.Remove(deleteCustomer);
        }


        public async Task<bool?> ThisCustomerNameExists(string customerName)
        {
            return await _dbContext.Customers
                .AnyAsync(src => src.ClientName!.ToLower() == customerName.ToLower());
        }

        
    }
}
