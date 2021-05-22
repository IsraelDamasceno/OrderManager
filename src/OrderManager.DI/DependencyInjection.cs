using Microsoft.Extensions.DependencyInjection;
using OrderManager.Interface.Repositories;
using OrderManager.Repository;

namespace OrderManager.DI
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProductRepository, ProductRepository>();
            serviceProvider.AddScoped<ICityRepository, CityRepository>();
            //serviceProvider.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
