using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.DTOs
{
    public class OrderDto
    {
        private string _imageSource;
     
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public string ImageSource
        {
            get => ".." + _imageSource;
            set => _imageSource = value;
        }
    }
}
