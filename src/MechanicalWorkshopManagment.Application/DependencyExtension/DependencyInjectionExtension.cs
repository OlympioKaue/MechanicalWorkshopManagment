using MechanicalWorkshopManagment.Application.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MechanicalWorkshopManagment.Application.DependencyExtension
{
    /// <summary>
    /// Classe de extensão de independência.
    /// </summary>
    public static class DependencyInjectionExtension
    {
        public static void AddExtensionInjection(this IServiceCollection services)
        {
            RegisterUseCaseFromAssembly(services);
        }

        private static void RegisterUseCaseFromAssembly(this IServiceCollection service)
        {

            var assembly = typeof(IGenericUseCase).Assembly;

            assembly.GetTypes()
                .Where(ass => ass.IsClass && !ass.IsAbstract)
                .SelectMany(ass => ass.GetInterfaces()
                .Where(ass => ass != typeof(IGenericUseCase) && typeof(IGenericUseCase).IsAssignableFrom(ass)),
                (implemention, iface) => new {iface, implemention})
                .ToList()
                .ForEach(ass => service.AddScoped(ass.iface, ass.implemention));
               
              
        }
    }
}
