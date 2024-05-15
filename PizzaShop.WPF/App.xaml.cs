using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaShop.Application.Interface;
using PizzaShop.Persistence.Context;
using PizzaShop.Persistence.Repositories;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using PizzaShop.WPF.View;
using PizzaShop.WPF.VIewModel;
using System;
using System.Windows;

namespace PizzaShop.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {

        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    service.AddSingleton<PizzaShopDbContextFactory>();
                    service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    service.AddSingleton<NavigationStore>();

                    service.AddSingleton<MainWindowViewModel>();

                    service.AddTransient<PizzaViewModel>();
                    service.AddSingleton<Func<PizzaViewModel>>(s => () => s.GetRequiredService<PizzaViewModel>());
                    service.AddSingleton<NavigationService<PizzaViewModel>>();

                    service.AddSingleton<NavigationService<PizzaViewModel>>();

                    service.AddSingleton<MainWindow>(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
                    });

                    service.AddScoped<IPizzaService, PizzaService>();
                    service.AddScoped<IPizzaRepository, PizzaRepository>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            NavigationService<PizzaViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<PizzaViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
