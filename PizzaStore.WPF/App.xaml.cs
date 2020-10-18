using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using PizzaStore.Infrastructure.Services;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
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
            IDataService<Product> productDataService = serviceProvider.GetRequiredService<IDataService<Product>>();

            Window window = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            };

            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDataService<Product>, HardCodedProductDataService>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}