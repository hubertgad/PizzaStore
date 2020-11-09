using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Utilities.Collections;
using PizzaStore.Domain;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Infrastructure;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.Services;
using PizzaStore.WPF.State.Authenticators;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using PizzaStore.WPF.ViewModels.Factories;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace PizzaStore.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    c.AddUserSecrets(Assembly.GetExecutingAssembly());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrastructure(context.Configuration);
                    services.AddDomain();

                    services.AddSingleton<IPizzaStoreViewModelFactory, PizzaStoreViewModelFactory>();

                    services.AddSingleton<CartViewModel>();
                    services.AddSingleton<OrderHistoryViewModel>();
                    services.AddSingleton<MenuViewModel>();

                    services.AddSingleton<CreateViewModel<MenuViewModel>>(s => () => s.GetRequiredService<MenuViewModel>());
                    services.AddSingleton<CreateViewModel<CartViewModel>>(s => () => s.GetRequiredService<CartViewModel>());
                    services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(() => new OrderHistoryViewModel());
                    services.AddSingleton<CreateViewModel<LoginViewModel>>(s =>
                    {
                        return () => new LoginViewModel(
                            s.GetRequiredService<IAuthenticator>(),
                            s.GetRequiredService<ViewModelDelegateRenavigator<MenuViewModel>>());
                    });

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<ViewModelDelegateRenavigator<MenuViewModel>>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddScoped<MainViewModel>();

                    services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            var context = _host.Services.GetRequiredService<PizzaStoreDbContext>();
            if (context.Users.Count() == 0)
            {
                PasswordHasher hasher = new PasswordHasher();
                context.Users.Add(new Domain.Models.User("hubertgad@gmail.com", "Hubret", hasher.HashPassword("aaa")));
                context.SaveChanges();
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}