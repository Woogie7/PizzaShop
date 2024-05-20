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
    class RegisterCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly RegisterViewModel _registerViewModel;

        public RegisterCommand(IAuthenticator authenticator, RegisterViewModel registerViewModel)
        {
            _authenticator = authenticator;
            _registerViewModel = registerViewModel;
        }

        //public override bool CanExecute(object parameter)
        //{
        //return _registerViewModel.CanRegister && base.CanExecute(parameter); ;
        //}
        public override async Task ExecuteAsync(object parameter)
        {
            var succes = await _authenticator.Register(_registerViewModel.User);

            _registerViewModel.PizzaNavigationCommand.Execute(succes);
        }
    }
}
