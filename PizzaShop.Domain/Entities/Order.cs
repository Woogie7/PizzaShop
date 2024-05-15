using PizzaShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Domain.Entities
{
    public class Order : Entity
    {
        public string OrderNumber { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public int Quantity { get; set; }
    }
}
