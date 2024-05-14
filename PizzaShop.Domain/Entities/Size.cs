using PizzaShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Domain.Entities
{
    public class Size : Entity
    {
        public string Name { get; set; }

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
