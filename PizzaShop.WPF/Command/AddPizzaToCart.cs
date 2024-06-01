using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command
{
    internal class AddPizzaToCart : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IOrderService _orderService;

        public AddPizzaToCart(IOrderService orderService, IAuthenticator authenticator)
        {
            _orderService = orderService;
            _authenticator = authenticator;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            if (parameter is PizzaDto pizza)
            {
                await _orderService.CreateOrder(pizza, _authenticator.CurrentUser);
                await
            }
        }
    }
}
