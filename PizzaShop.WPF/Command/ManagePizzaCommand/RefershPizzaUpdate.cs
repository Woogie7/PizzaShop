using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.ManagePizzaCommand
{
    class RefershPizzaUpdate : BaseCommand
    {

        private readonly ManagePizzaViewModel _viewModel;

        public RefershPizzaUpdate(ManagePizzaViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
