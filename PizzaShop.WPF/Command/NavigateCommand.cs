using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command
{
    internal class NavigateCommand<TViewModel> : BaseCommand where TViewModel : ObservaleObject
    {
        private readonly NavigationService<TViewModel> _navigationService;
        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
