using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Enum;

namespace PizzaShop.Application.Interface
{
    public interface IAuthenticator
    {
        UserDto CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(CreateUserDto userDto);
        Task<UserDto> Login(UserDto userDto);
        void Logout();

    }
}
