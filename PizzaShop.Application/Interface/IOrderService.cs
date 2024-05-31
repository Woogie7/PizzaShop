using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
    }
}
