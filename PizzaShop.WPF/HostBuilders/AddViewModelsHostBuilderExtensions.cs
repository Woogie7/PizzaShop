using Microsoft.Extensions.DependencyInjection;
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

                services.AddSingleton<NavigationService<PizzaViewModel>>();
                services.AddSingleton<NavigationService<LoginViewModel>>();
                services.AddSingleton<NavigationService<RegisterViewModel>>();

                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                });
            });
            return host;
        }
    }
}
