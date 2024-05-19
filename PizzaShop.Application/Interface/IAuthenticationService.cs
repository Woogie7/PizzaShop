using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface IAuthenticationService
    {
        Task<bool> Register(CreateUserDto userDto);
        Task<User> Login(string email, string password);
    }
}
