using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrueStory.Products.RestfulApi.Client;
using TrueStory.Products.RestfulApi.Services;

namespace TrueStory.Products.RestfulApi
{
    /// <summary>
    /// Extension methods for adding services to the DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register the Restful API client in the DI container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddRestfulApi(this IServiceCollection services, IConfiguration configuration)
        {
            // Restful Api Client
            return services.AddRestfulApiClient(configuration);
        }

        /// <summary>
        /// Registers the product service in the DI container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddProductService(this IServiceCollection services)
        {
            // Products Services
            return services.AddScoped<IProductService, ProductService>();
        }
    }
}
