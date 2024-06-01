using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.CartViewCommand
{
    internal class DecreaseQuantityCommand : AsyncCommandBase
    {
        private readonly CartViewModel _cartViewModel;
        private readonly IOrderService _orderService;

        public DecreaseQuantityCommand(CartViewModel cartViewModel, IOrderService orderService)
        {
            _cartViewModel = cartViewModel;
            _orderService = orderService;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is OrderDto order)
            {
                return order.Quantity > 0;
            }
            return false;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            if (parameter is OrderDto order)
            {
                await _orderService.DecreaseQuantity(order);
                await _cartViewModel.LoadOrdersAsync(); 
            }
        }
    }
}
