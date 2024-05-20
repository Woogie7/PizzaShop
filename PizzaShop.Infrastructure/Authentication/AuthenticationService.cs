using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Exceptions;

namespace PizzaShop.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IPasswordHasher hasher, IUserRepository userRepository)
        {
            _hasher = hasher;
            _userRepository = userRepository;
        }

        public async Task<User> Login(UserDto userDto)
        {
            var user = await _userRepository.GetUserByEmail(userDto.Email);

            if(user == null)
            {
                throw new UserNotFoundException(userDto.Email);
            }

            var result = _hasher.IsVerify(userDto.PasswordHash, user.PasswordHash);

            if (!result)
            {
                throw new InvalidPasswordException(user.Email, user.PasswordHash);
            }

            return user;
        }

        public async Task<bool> Register(CreateUserDto userDto)
        {
            var hashedPassword = _hasher.GeneratePassword(userDto.PasswordHash);

            var userEmail = _userRepository.GetUserByEmail(userDto.Email);

            if (userEmail.Result.Email != null)
            {
                throw new Exception("Почта занята");
            }


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
