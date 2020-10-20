using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Infrastructure.Services;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.State.Basket;
using PizzaStore.WPF.ViewModels;
using PizzaStore.WPF.ViewModels.Factories;
using System;
using System.Windows;

namespace PizzaStore.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDataService<Product>, HardCodedProductDataService>();

            services.AddSingleton<IPizzaStoreViewModelAbstractFactory, PizzaStoreViewModelAbstractFactory>();
            services.AddSingleton<IPizzaStoreViewModelFactory<MenuViewModel>, MenuViewModelFactory>();
            services.AddSingleton<IPizzaStoreViewModelFactory<BasketViewModel>, BasketViewModelFactory>();
            services.AddSingleton<IPizzaStoreViewModelFactory<OrderHistoryViewModel>, OrderHistoryViewModelFactory>();
            services.AddSingleton<IBasket, Basket>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}