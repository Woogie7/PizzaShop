using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.DTOs.Pizza
{
    public class CreatePizzaDto
    {
        public string Name { get; set; }
        public int[] IngredientsId { get; set; }

        public int SizeId { get; set; }

        public int CategoryId { get; set; }

        [MinLength(10)]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
