using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.DTOs.User;
using PizzaShop.Domain.Entities;
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
        Task CreateOrder(PizzaDto pizzaDto, UserDto user);
        Task IncreaseQuantity(OrderDto orderDto);
        Task DecreaseQuantity(OrderDto orderDto);
    }
}
