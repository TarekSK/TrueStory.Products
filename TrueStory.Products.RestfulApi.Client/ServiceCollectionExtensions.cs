using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace TrueStory.Products.RestfulApi.Client
{
    /// <summary>
    /// Extension methods for adding services to the DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register the Restful API client in the DI container.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddRestfulApiClient(
            this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .Configure<RestfulApiOptions>(configuration.GetSection(RestfulApiOptions.Section))
                .AddRefitClient<IRestfulApiClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<RestfulApiOptions>>().Value;
                    client.BaseAddress = options.BaseAddress;
                });

            return serviceCollection;
        }
    }
}
