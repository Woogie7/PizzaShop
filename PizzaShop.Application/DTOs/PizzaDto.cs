﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.DTOs
{
    public class PizzaDto
    {
        public string Name { get; set; }
        public string[] Ingredients { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}