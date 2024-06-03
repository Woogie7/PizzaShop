using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.VIewModel;
using PizzaShop.Application.Interface;

namespace PizzaShop.WPF.Command
{
    class ToggleCartCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly ICartService _cartService;

        public ToggleCartCommand(MainWindowViewModel mainWindowViewModel, ICartService cartService)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _cartService = cartService;
        }

        public override void Execute(object parameter)
        {
            _mainWindowViewModel.IsCartVisible = !_mainWindowViewModel.IsCartVisible;
            _cartService.ClearOrders();
        }
    }

}
