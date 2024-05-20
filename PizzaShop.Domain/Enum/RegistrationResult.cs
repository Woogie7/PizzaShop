using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Domain.Enum
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
    }
}
