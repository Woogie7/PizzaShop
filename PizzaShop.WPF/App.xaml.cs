using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaShop.Application.Interface;
using PizzaShop.Infrastructure;
using PizzaShop.Persistence.Context;
using PizzaShop.Persistence.Repositories;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using PizzaShop.WPF.View;
using PizzaShop.WPF.VIewModel;
using System;
using System.Windows;
using PizzaShop.Infrastructure.Authentication;
using PizzaShop.WPF.HostBuilders;
using PizzaShop.Application.Interface.Repository;

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
                .AddViewModels()
                .ConfigureServices((context, service) =>
                {
                    service.AddSingleton<PizzaShopDbContextFactory>();

                    service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                    service.AddSingleton<IPasswordHasher, PasswordHasher>();

                    service.AddSingleton<NavigationStore>();

                    service.AddSingleton<IAuthenticationService, AuthenticationService>();
                    service.AddScoped<IAuthenticator, Authenticator>();
                    service.AddScoped<IPizzaService, PizzaService>();
                    service.AddScoped<IOrderService, OrderService>();
                    service.AddScoped<ISizeService, SizeService>();
                    service.AddScoped<ICategorySevice, CategoryService>();
                    service.AddScoped<IIngredientService, IngredientService>();
                    service.AddScoped<ICartService, CartService>();

                    service.AddScoped<IPizzaRepository, PizzaRepository>();
                    service.AddScoped<IOrderRepository, OrderRepository>();
                    service.AddScoped<ISizeRepository, SizeRepository>();
                    service.AddScoped<ICategoryRepository, CategoryRepository>();
                    service.AddScoped<IIngredientRepository, IngredientRepository>();
                    service.AddScoped<IUserRepository, UserRepository>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();            

            NavigationService<LoginViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<LoginViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
