using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(CreateUserDto userDto);
        Task<User> Login(UserDto userDto);
    }
}
