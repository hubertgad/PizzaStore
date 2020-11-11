using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.Domain;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Infrastructure;
using PizzaStore.Infrastructure.Services;
using PizzaStore.WPF.State.Authenticators;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using PizzaStore.WPF.ViewModels.Factories;
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
                    services.AddDomain(context.Configuration);
                    services.AddInfrastructure(context.Configuration);

                    services.AddSingleton<IPizzaStoreViewModelFactory, PizzaStoreViewModelFactory>();

                    services.AddSingleton<CartViewModel>();
                    services.AddSingleton<OrderHistoryViewModel>();

                    services.AddSingleton<CreateViewModel<CartViewModel>>(s => () => s.GetRequiredService<CartViewModel>());
                    services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(s => () => new OrderHistoryViewModel());
                    services.AddSingleton<CreateViewModel<MenuViewModel>>(s =>
                    {
                        return () => new MenuViewModel(
                            s.GetRequiredService<IProductDataService>(),
                            s.GetRequiredService<CartViewModel>(),
                            s.GetRequiredService<ViewModelDelegateRenavigator<CartViewModel>>());
                    });
                    services.AddSingleton<CreateViewModel<RegisterViewModel>>(s =>
                    {
                        return () => new RegisterViewModel(
                            s.GetRequiredService<IAuthenticator>(),
                            s.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
                    });
                    services.AddSingleton<CreateViewModel<LoginViewModel>>(s =>
                    {
                        return () => new LoginViewModel(
                            s.GetRequiredService<IAuthenticator>(),
                            s.GetRequiredService<ViewModelDelegateRenavigator<MenuViewModel>>(),
                            s.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
                    });

                    services.AddSingleton<ViewModelDelegateRenavigator<MenuViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<CartViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddScoped<MainViewModel>();

                    services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            _host.Services.GetRequiredService<DataSeeder>().SeedDatabase();

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