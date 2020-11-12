using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Domain.Services.AuthenticationServices;
using PizzaStore.Domain.Services.EmailServices;
using PizzaStore.Domain.Services.OrderServices;

namespace PizzaStore.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IPlaceOrderService, PlaceOrderService>();

            services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}