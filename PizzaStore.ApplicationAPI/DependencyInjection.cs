using Microsoft.Extensions.DependencyInjection;
using PizzaStore.ApplicationApi.Interfaces;
using PizzaStore.ApplicationApi.Services;

namespace PizzaStore.ApplicationApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationAPI(this IServiceCollection services)
        {
            services.AddSingleton<IProductApiService, ProductApiService>();

            return services;
        }
    }
}