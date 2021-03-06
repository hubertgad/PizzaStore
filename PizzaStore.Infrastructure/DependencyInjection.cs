﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Domain.Services;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.Services;

namespace PizzaStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<PizzaStoreDbContext>(o =>
                o.UseLazyLoadingProxies()
                 .UseSqlServer(connectionString));

            services.AddSingleton<IProductDataService, ProductDataService>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<IOrderDataService, OrderDataService>();

            services.AddSingleton<DataSeeder>();

            return services;
        }
    }
}