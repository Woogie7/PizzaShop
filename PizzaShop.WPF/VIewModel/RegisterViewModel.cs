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

        public string UserName
        {
            get => User.UserName;
            set
            {
                if (User.UserName != value)
                {
                    User.UserName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CanRegister));
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
                    OnPropertyChanged(nameof(CanRegister));
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
                    OnPropertyChanged(nameof(CanRegister));
                }
            }
        }

        #endregion

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(UserName) &&
            !string.IsNullOrEmpty(PasswordHash);

        public ICommand RegisterCommand { get; }

        public ICommand LoginNavigationCommand { get; }
        public ICommand PizzaNavigationCommand { get; }

        public RegisterViewModel(IAuthenticator authenticator, NavigationService<PizzaViewModel> navigationServicePizza, NavigationService<LoginViewModel> navigationServiceLogin)
        {

            _authenticator = authenticator;
            User = new CreateUserDto();

            RegisterCommand = new RegisterCommand(_authenticator, this);
            PizzaNavigationCommand = new NavigateCommand<PizzaViewModel>(navigationServicePizza);
            LoginNavigationCommand = new NavigateCommand<LoginViewModel>(navigationServiceLogin);
        }

    }
}

