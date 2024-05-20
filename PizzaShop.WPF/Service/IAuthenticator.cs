﻿using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(CreateUserDto userDto);
        Task<User> Login(UserDto userDto);
        void Logout();

    }
}