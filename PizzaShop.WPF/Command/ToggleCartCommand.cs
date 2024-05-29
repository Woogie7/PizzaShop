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

namespace PizzaShop.WPF.Command
{
    class ToggleCartCommand : BaseCommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public ToggleCartCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            _mainWindowViewModel.IsCartVisible = !_mainWindowViewModel.IsCartVisible;
        }
    }

}
