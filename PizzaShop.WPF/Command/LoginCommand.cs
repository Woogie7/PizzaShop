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
    class LoginCommand : BaseCommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override async void Execute(object parameter)
        {
            var succes = await _authenticator.Login(_loginViewModel.User);
        }
    }
}
