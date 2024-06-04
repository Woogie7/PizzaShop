using PizzaShop.Application.Interface;
using PizzaShop.Domain.Enum;
using PizzaShop.WPF.Core;
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
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                var succes = await _authenticator.Register(_registerViewModel.User);


                switch (succes)
                {
                    case RegistrationResult.Success:
                        _registerViewModel.LoginNavigationCommand.Execute(succes);
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessage = "Неправильный пароль.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "Email уже используеться.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Ошибка регистрации.";
                        break;
                }

                
            }
            catch(Exception)
            {
                _registerViewModel.ErrorMessage = "Ошибка регистрации.";
            }
        }
    }
}
