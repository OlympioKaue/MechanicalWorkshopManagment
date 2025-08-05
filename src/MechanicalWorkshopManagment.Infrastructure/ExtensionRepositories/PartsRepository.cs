using MechanicalWorkshopManagment.Communication.Enums;
using MechanicalWorkshopManagment.Domain.Entities;
using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWorkshopManagment.Infrastructure.ExtensionRepositories
{
    /// <summary>
    /// Classe que herda interfaces do tipo (Parts).
    /// </summary>
    internal class PartsRepository : IParts
    {
        private readonly MechanicalManagmentDbContext _dbContext;

        public PartsRepository(MechanicalManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPartAsync(Parts createPart)
        {

            await _dbContext.Parts.AddAsync(createPart);
            await _dbContext.SaveChangesAsync();
        }


        public void UpdatePart(Parts updatePart)
        {

            _dbContext.Parts.Update(updatePart);
        }

        public async Task<List<Parts>> GetPartsAllAsync()
        {
            return await _dbContext.Parts.AsNoTracking().OrderBy(src => src.Id).ToListAsync();

        }

        public async Task<Parts?> GetPartsByIdAsync(int idParts)
        {
            return await _dbContext.Parts.AsNoTracking().FirstOrDefaultAsync(src => src.Id == idParts);
        }

        public void DeletePart(Parts deletePart)
        {
            _dbContext.Parts.Remove(deletePart);
        }

        public async Task<bool?> ThePartsNameExists(string partsName)
        {
            return await _dbContext.Parts.AsNoTracking().AnyAsync(src => src.Name!.ToLower() == partsName.ToLower());
        }

        public async Task<Parts?> ThisPartsExistsWithID(int idParts)
        {
            return await _dbContext.Parts
                .FirstOrDefaultAsync(src => src.Id == idParts);

        }

      
    }
}



