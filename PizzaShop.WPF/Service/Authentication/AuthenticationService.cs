using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service.Authentication
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IPasswordHasher hasher, IUserRepository userRepository)
        {
            _hasher = hasher;
            _userRepository = userRepository;
        }

        public Task<User> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(CreateUserDto userDto)
        {
            var hashedPassword = _hasher.GeneratePassword(userDto.PasswordHash);

            var user = new CreateUserDto
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
                PasswordHash = hashedPassword,
            };

            await _userRepository.Add(user);

            return true;
        }
    }
}
