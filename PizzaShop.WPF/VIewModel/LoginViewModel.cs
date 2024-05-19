using PizzaShop.Application.DTOs.User;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    internal class LoginViewModel : ObservaleObject
    {
        private readonly IAuthenticator _authenticator;
        private UserDto _user;



        public ICommand LoginCommand { get; }
        public ICommand RegisterNavigationCommand { get; }

        #region Свойства
        public UserDto User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }



        public string Email
        {
            get => User.Email;
            set
            {
                if (User.Email != value)
                {
                    User.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PasswordHash
        {
            get => User.PasswordHash;
            set
            {
                if (User.PasswordHash != value)
                {
                    User.PasswordHash = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public LoginViewModel(IAuthenticator authenticator, NavigationService<RegisterViewModel> navigationService)
        {
            _authenticator = authenticator;
            User = new UserDto();
            LoginCommand = new LoginCommand(_authenticator, this);
            RegisterNavigationCommand = new NavigateCommand<RegisterViewModel>(navigationService);
        }
    }
}
