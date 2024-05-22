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
    class LogoutCommand : BaseCommand
    {
        private readonly IAuthenticator _authenticator;

        private readonly MainWindowViewModel _mainViewModel;
        public LogoutCommand(IAuthenticator authenticator, MainWindowViewModel mainViewModel)
        {
            _authenticator = authenticator;
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _mainViewModel.IsLoggedIn && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _authenticator.Logout();
            _mainViewModel.LoginNavigateCommand.Execute(parameter);
        }
    }
}
