using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);

        bool IsVerify(string password, string hashedPassword);
    }
}

