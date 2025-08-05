using MechanicalWorkshopManagment.Domain.Repositories;
using MechanicalWorkshopManagment.Infrastructure.DataAcess;
using MechanicalWorkshopManagment.Infrastructure.ExtensionRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MechanicalWorkshopManagment.Infrastructure.DependencyExtension
{
    /// <summary>
    /// Classe de extensão de independência.
    /// </summary>
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IParts, PartsRepository>();
            services.AddScoped<IBuys, BuyRepository>();
            services.AddScoped<ISaveChangesWorks, SaveRepository>();
            services.AddScoped<IViaCep, ViaCepRepository>();
            services.AddScoped<IPartsBudgets, PartsBudgetRepository>();
            services.AddScoped<IStockMovements, StockMovementsRepository>();
            services.AddScoped<IDelivery, DeliveryRepository>();
            services.AddScoped<ICustomer, CustomerRepository>();


        }



        //Conecte o banco de dados PostegreSQL.
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MechanicalManagmentDbContext>(options =>
                options.UseNpgsql(connection, b =>
                b.MigrationsAssembly("MechanicalWorkshopManagment.Infrastructure")));


        }

    }
}

