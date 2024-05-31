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
    internal class DecreaseQuantityCommand : BaseCommand
    {
        private readonly CartViewModel _cartViewModel;

        public DecreaseQuantityCommand(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter is OrderDto order)
            {
                return order.Quantity > 0;
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if (parameter is OrderDto order)
            {
                order.Quantity--;
                _cartViewModel.UpdateTotals();
            }
        }
    }
}
