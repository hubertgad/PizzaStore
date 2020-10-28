using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.Infrastructure;
using PizzaStore.WPF.State.Cart;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using PizzaStore.WPF.ViewModels.Factories;
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
                    c.AddUserSecrets(System.Reflection.Assembly.GetExecutingAssembly());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrastructure(context.Configuration);

                    services.AddSingleton<IPizzaStoreViewModelAbstractFactory, PizzaStoreViewModelAbstractFactory>();
                    services.AddSingleton<IPizzaStoreViewModelFactory<MenuViewModel>, MenuViewModelFactory>();
                    services.AddSingleton<IPizzaStoreViewModelFactory<CartViewModel>, CartViewModelFactory>();
                    services.AddSingleton<IPizzaStoreViewModelFactory<OrderHistoryViewModel>, OrderHistoryViewModelFactory>();
                    services.AddSingleton<ICart, Cart>();
                    services.AddScoped<INavigator, Navigator>();
                    services.AddScoped<MainViewModel>();

                    services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

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