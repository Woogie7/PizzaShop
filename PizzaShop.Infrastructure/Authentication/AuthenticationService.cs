using AutoMapper;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.User;
using PizzaShop.Application.Interface;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using PizzaShop.Domain.Exceptions;
using System.Security.Principal;

namespace PizzaShop.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _hasher;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IPasswordHasher hasher, IUserRepository userRepository, IMapper mapper)
        {
            _hasher = hasher;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Login(UserDto userDto)
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

            userDto.Id = user.Id.ToString();
            userDto.Role = user.Role.Name;

            return userDto;
        }

        public async Task<RegistrationResult> Register(CreateUserDto userDto)
        {
            RegistrationResult registrationResult = RegistrationResult.Success;

            var user = await _userRepository.GetUserByEmail(userDto.Email);

            if (user != null)
            {
                registrationResult = RegistrationResult.EmailAlreadyExists;
            }

            if (registrationResult == RegistrationResult.Success)
            {
                var hashedPassword = _hasher.GeneratePassword(userDto.PasswordHash);

                var newUser = new CreateUserDto
                {
                    Email = userDto.Email,
                    UserName = userDto.UserName,
                    PasswordHash = hashedPassword,
                };

                await _userRepository.Add(newUser);
            }

            return registrationResult;
        }
    }
}
