using Microsoft.Extensions.DependencyInjection;

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

        }
    }
}
