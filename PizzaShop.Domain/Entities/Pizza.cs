using PizzaShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PizzaShop.Domain.Entities
{
    public class Pizza : Entity
    {
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
       
        public int SizeId { get; set; }

        public Size? Size { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = string.IsNullOrWhiteSpace(value) ? "../Images/defaultPizza.jpg" : value;
            }
        }
    }
}
