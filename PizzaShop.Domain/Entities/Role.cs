using PizzaShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace PizzaShop.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
