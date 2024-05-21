using PizzaShop.Application.DTOs.User;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    internal class LoginViewModel : ObservaleObject, INotifyDataErrorInfo
    {
        private readonly ErrorValidationViewModel _errorValidationViewModel;

        private readonly IAuthenticator _authenticator;
        private UserDto _user;

        public ICommand LoginCommand { get; }
        public ICommand RegisterNavigationCommand { get; }
        public ICommand PizzaNavigationCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage 
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public bool CanCreate => !HasErrors;

        public bool HasErrors => _errorValidationViewModel.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


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


        private string _email;
        public string Email
        {
            get => User.Email;
            set
            {
                if (User.Email != value)
                {
                    User.Email = value;

                    ValidateEmail();
                    OnPropertyChanged();
                }
            }
        }

        private string _passwordHash;
        public string PasswordHash
        {
            get => User.PasswordHash;
            set
            {
                if (User.PasswordHash != value)
                {
                    User.PasswordHash = value;

                    ValidatePasswordHash();
                    OnPropertyChanged();
                }
            }
        }

        

        #endregion

        public LoginViewModel(IAuthenticator authenticator, NavigationService<PizzaViewModel> navigationServicePizza, NavigationService<RegisterViewModel> navigationServiceReg)
        {
            _authenticator = authenticator;
            User = new UserDto();


            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(_authenticator, this);
            PizzaNavigationCommand = new NavigateCommand<PizzaViewModel>(navigationServicePizza);
            RegisterNavigationCommand = new NavigateCommand<RegisterViewModel>(navigationServiceReg);

            _errorValidationViewModel = new ErrorValidationViewModel();
            _errorValidationViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
  
            ValidateEmail();
            ValidatePasswordHash();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorValidationViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }

        private void ValidateEmail()
        {
            _errorValidationViewModel.ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
            {
                _errorValidationViewModel.AddError(nameof(Email), "Email обязательное поле!");
            }
            else if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                _errorValidationViewModel.AddError(nameof(Email), "Не корректный email.");
            }
        }

        public void ValidatePasswordHash()
        {
            _errorValidationViewModel.ClearErrors(nameof(PasswordHash));
            if (string.IsNullOrWhiteSpace(PasswordHash))
            {
                _errorValidationViewModel.AddError(nameof(PasswordHash), "Пароль обязательное поле!");
            }
            else if (PasswordHash.Length < 3)
            {
                _errorValidationViewModel.AddError(nameof(PasswordHash), "Пароль меньше 5 символов.");
            }
            else if (PasswordHash.Length > 15)
            {
                _errorValidationViewModel.AddError(nameof(PasswordHash), "Пароль больше 15 символов.");
            }
        }

    }

}
