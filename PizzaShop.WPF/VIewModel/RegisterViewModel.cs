using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    internal class RegisterViewModel : ObservaleObject, INotifyDataErrorInfo
    {
        private readonly ErrorValidationViewModel _errorValidation;
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

                    ValidateName();

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

                    ValidateEmail();

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

                    ValidatePasswordHash();

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

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public bool CanCreate => !HasErrors;

        public bool HasErrors => _errorValidation.HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public RegisterViewModel(IAuthenticator authenticator, NavigationService<LoginViewModel> navigationServiceLogin)
        {

            _authenticator = authenticator;
            User = new CreateUserDto();

            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(_authenticator, this);
            LoginNavigationCommand = new NavigateCommand<LoginViewModel>(navigationServiceLogin);

            _errorValidation= new ErrorValidationViewModel();
            _errorValidation.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            ValidateEmail();
            ValidatePasswordHash();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorValidation.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(CanCreate));
        }

        private void ValidateEmail()
        {
            _errorValidation.ClearErrors(nameof(Email));
            if (string.IsNullOrWhiteSpace(Email))
            {
                _errorValidation.AddError(nameof(Email), "Email обязательное поле!");
            }
            else if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                _errorValidation.AddError(nameof(Email), "Не корректный email.");
            }
        }

        public void ValidatePasswordHash()
        {
            _errorValidation.ClearErrors(nameof(PasswordHash));
            if (string.IsNullOrWhiteSpace(PasswordHash))
            {
                _errorValidation.AddError(nameof(PasswordHash), "Пароль обязательное поле!");
            }
            else if (PasswordHash.Length < 3)
            {
                _errorValidation.AddError(nameof(PasswordHash), "Пароль меньше 5 символов.");
            }
            else if (PasswordHash.Length > 15)
            {
                _errorValidation.AddError(nameof(PasswordHash), "Пароль больше 15 символов.");
            }
        }

        public void ValidateName()
        {
            _errorValidation.ClearErrors(nameof(UserName));
            if(string.IsNullOrEmpty(UserName))
            {
                _errorValidation.AddError(nameof(UserName), "Имя обязательное поле!");
            }
        }

    }
}

