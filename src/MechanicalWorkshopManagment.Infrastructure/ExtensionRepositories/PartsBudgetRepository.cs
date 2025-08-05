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
    /// Classe que herda interfaces do tipo (PartsBudgets).
    /// </summary>
    internal class PartsBudgetRepository : IPartsBudgets
    {
        private readonly MechanicalManagmentDbContext _dbContext;
        private readonly ISaveChangesWorks _save;

        public PartsBudgetRepository(MechanicalManagmentDbContext dbContext, ISaveChangesWorks save)
        {
            _dbContext = dbContext;
            _save = save;
        }

        public async Task AddPartsBudgetAsync(PartsBudget partsBudget)
        {
            await _dbContext.PartsBudgets.AddAsync(partsBudget);
        }

     
        public async Task<bool> UpdatePartsBudgetAsync(PartsBudget partsBudget)
        {  
            return await Task.FromResult(true);
        }

        public async Task<List<PartsBudget>> GetAllPartsBudgetsAsync()
        {
            return await _dbContext.PartsBudgets
                .Include(src => src.Customer)
                .OrderBy(src => src.Id)
                .ToListAsync();
        }

        public async Task<List<PartsBudget>> GetSelectedPartsBudget(int idCustomer)
        {
            return await _dbContext.PartsBudgets
                .AsNoTracking()
                .Where(src => src.CustomerId == idCustomer)
                .ToListAsync();
        }

 
        public async Task<List<PartsBudget>> GetPartsBudgetWithList(int idCustomer)
        {
            return await _dbContext.PartsBudgets
                .Where(src => src.CustomerId == idCustomer)
                .ToListAsync();
        }

        public void DeletePartsBudget(PartsBudget deletePartsBudget)
        {
            _dbContext.PartsBudgets.RemoveRange(deletePartsBudget);
        }

        public async Task DeletePartsBudgetPurchaseDenied(List<PartsBudget> deletePartsBudgetPurchaseDenied)
        {
            _dbContext.PartsBudgets.RemoveRange(deletePartsBudgetPurchaseDenied);
            await _save.SaveChangesAsync();
          
        }
    }
}
