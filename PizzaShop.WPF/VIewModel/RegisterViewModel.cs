using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
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
    internal class RegisterViewModel : ObservaleObject
    {
        private readonly IAuthenticator _authenticator;
        private CreateUserDto _user;

        #region АВАЫ

        public CreateUserDto User
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
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        #endregion

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(Password);

        public ICommand RegisterCommand { get; }

        public ICommand LoginNavigationCommand { get; }

        public RegisterViewModel(IAuthenticator authenticator, NavigationService<LoginViewModel> navigationService)
        {

            _authenticator = authenticator;
            User = new CreateUserDto();

            RegisterCommand = new RegisterCommand();
            LoginNavigationCommand = new NavigateCommand<LoginViewModel>(navigationService);
        }

    }
}

