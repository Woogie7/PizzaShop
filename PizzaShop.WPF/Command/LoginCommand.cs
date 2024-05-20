using PizzaShop.Domain.Exceptions;
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
    class LoginCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                var succes = await _authenticator.Login(_loginViewModel.User);

                _loginViewModel.PizzaNavigationCommand.Execute(succes);
            }
            catch(UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Пользователь не найден";
            }
            catch(InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Не правильный пароль";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Ошибка входа";
            }
            
        }
    }
}
