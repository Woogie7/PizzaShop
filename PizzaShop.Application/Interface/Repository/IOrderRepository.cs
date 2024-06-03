using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface.Repository
{

    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task CreateOrder(OrderDto orderDto);
        Task DeleteOrder(OrderDto orderDto);
        Task IncreaseQuantity(OrderDto orderDto);
        Task DecreaseQuantity(OrderDto orderDto);
    }
}
