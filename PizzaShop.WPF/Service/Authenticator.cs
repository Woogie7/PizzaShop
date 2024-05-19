using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service
{
    class Authenticator : ObservaleObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<User> Login(UserDto userDto)
        {

            try
            {
                CurrentUser = await _authenticationService.Login(userDto);
            }
            catch (Exception ex)
            {
                return null;
            }

            return CurrentUser;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<bool> Register(CreateUserDto userDto)
        {
            return await _authenticationService.Register(userDto);
        }
    }
}
