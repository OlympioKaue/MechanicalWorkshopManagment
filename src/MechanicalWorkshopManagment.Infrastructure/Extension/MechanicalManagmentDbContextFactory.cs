using MechanicalWorkshopManagment.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MechanicalWorkshopManagment.Infrastructure.Extension
{
    public class MechanicalManagmentDbContextFactory : IDesignTimeDbContextFactory<MechanicalManagmentDbContext>
    {
        public MechanicalManagmentDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MechanicalManagmentDbContext>();
            optionsBuilder.UseNpgsql(connectionString, b =>
                b.MigrationsAssembly(typeof(MechanicalManagmentDbContext).Assembly.FullName));

            return new MechanicalManagmentDbContext(optionsBuilder.Options);

        }
    }
}
