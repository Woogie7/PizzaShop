
using PizzaShop.Application.Interface;

namespace PizzaShop.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GeneratePassword(string password)
        {
            try
            {
                return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating hashed password", ex);
            }
        }

        public bool IsVerify(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("Error verifying password", ex);
            }
        }
    }
}