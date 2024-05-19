using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface IUserRepository
    {
        Task Add(CreateUserDto user);
        Task<User> GetUserByEmail(string email);
    }
}
