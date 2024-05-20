using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string EmailUser { get; set; }
        public string Password { get; set; }

        public InvalidPasswordException(string emailUser, string password)
        {
            EmailUser = emailUser;
            Password = password;
        }

        public InvalidPasswordException(string message, string username, string password) : base(message)
        {
            EmailUser = username;
            Password = password;
        }

        public InvalidPasswordException(string message, Exception innerException, string username, string password) : base(message, innerException)
        {
            EmailUser = username;
            Password = password;
        }
    }
}
