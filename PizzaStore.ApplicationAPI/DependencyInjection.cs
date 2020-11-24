using Microsoft.Extensions.DependencyInjection;
using PizzaStore.ApplicationAPI.Interfaces;
using PizzaStore.ApplicationAPI.Services;

namespace PizzaStore.ApplicationAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationAPI(this IServiceCollection services)
        {
            services.AddSingleton<IProductAPIService, ProductAPIService>();

            return services;
        }
    }
}