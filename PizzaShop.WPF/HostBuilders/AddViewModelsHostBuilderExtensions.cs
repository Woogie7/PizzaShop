﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaShop.WPF.Service.Store;
using PizzaShop.WPF.View;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindowViewModel>();


                services.AddTransient<PizzaViewModel>();
                services.AddSingleton<Func<PizzaViewModel>>(s => () => s.GetRequiredService<PizzaViewModel>());
                services.AddSingleton<NavigationService<PizzaViewModel>>();

                services.AddTransient<LoginViewModel>();
                services.AddSingleton<Func<LoginViewModel>>(s => () => s.GetRequiredService<LoginViewModel>());
                services.AddSingleton<NavigationService<LoginViewModel>>();

                services.AddTransient<RegisterViewModel>();
                services.AddSingleton<Func<RegisterViewModel>>(s => () => s.GetRequiredService<RegisterViewModel>());
                services.AddSingleton<NavigationService<RegisterViewModel>>();

                services.AddTransient<ManagePizzaViewModel>();
                services.AddSingleton<Func<ManagePizzaViewModel>>(s => () => s.GetRequiredService<ManagePizzaViewModel>());
                services.AddSingleton<NavigationService<ManagePizzaViewModel>>();

                services.AddTransient<CartViewModel>();
                services.AddSingleton<Func<CartViewModel>>(s => () => s.GetRequiredService<CartViewModel>());
                services.AddSingleton<NavigationService<CartViewModel>>();
                
                services.AddTransient<ReportViewModel>();
                services.AddSingleton<Func<ReportViewModel>>(s => () => s.GetRequiredService<ReportViewModel>());
                services.AddSingleton<NavigationService<ReportViewModel>>();

                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                });
            });
            return host;
        }
    }
}
