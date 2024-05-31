using PizzaShop.Application.DTOs;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.CartViewCommand
{
    internal class IncreaseQuantityCommand : BaseCommand
    {
        private readonly CartViewModel _cartViewModel;

        public IncreaseQuantityCommand(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is OrderDto order)
            {
                order.Quantity++;
                _cartViewModel.UpdateTotals();
            }
        }
    }
}
