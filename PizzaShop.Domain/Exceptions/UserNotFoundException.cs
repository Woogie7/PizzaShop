using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string EmailUser { get; set; }

        public UserNotFoundException(string emailUser)
        {
            EmailUser = emailUser;
        }

        public UserNotFoundException(string message, string emailUser) : base(message)
        {
            EmailUser = emailUser;
        }

        public UserNotFoundException(string message, Exception innerException, string emailUser) : base(message, innerException)
        {
            EmailUser = emailUser;
        }
    }
}
