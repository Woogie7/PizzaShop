using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public override void Execute(object parameter)
        {
            _authenticator.Logout();
            _mainViewModel.LoginNavigateCommand.Execute(parameter);
        }
    }
}
