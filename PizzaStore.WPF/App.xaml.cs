using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.Domain;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Infrastructure;
using PizzaStore.WPF.State.Authenticators;
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
                    services.AddDomain();

                    services.AddSingleton<IPizzaStoreViewModelFactory, PizzaStoreViewModelFactory>();

                    services.AddSingleton<CartViewModel>();
                    services.AddSingleton<OrderHistoryViewModel>();
                    services.AddSingleton<MenuViewModel>(s => 
                        new MenuViewModel(s.GetRequiredService<ICart>(), s.GetRequiredService<IProductDataService>()));

                    services.AddSingleton<CreateViewModel<MenuViewModel>>(s =>
                    {
                        return () => s.GetRequiredService<MenuViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<CartViewModel>>(s => () => new CartViewModel(s.GetRequiredService<ICart>()));

                    services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(() => new OrderHistoryViewModel());

                    services.AddSingleton<ViewModelDelegateRenavigator<MenuViewModel>>();

                    services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                    {
                        return () => new LoginViewModel(
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<MenuViewModel>>());
                    });

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<ICart, Cart>();
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