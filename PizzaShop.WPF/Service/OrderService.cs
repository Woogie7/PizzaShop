using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShop.Application.DTOs;
using PizzaShop.Domain.Entities;
using PizzaShop.Application.DTOs.User;

namespace PizzaShop.WPF.Service
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task IncreaseQuantity(OrderDto orderDto)
        {
            await _orderRepository.IncreaseQuantity(orderDto);
        }
        public async Task DecreaseQuantity(OrderDto orderDto)
        {
            await _orderRepository.DecreaseQuantity(orderDto);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task CreateOrder(PizzaDto pizzaDto, UserDto userDto)
        {
            var orderDto = new OrderDto()
            {
                ImageSource = pizzaDto.ImageSource,
                OrderNumber = "503",
                PizzaName = pizzaDto.Name,
                Quantity = 1,
                TotalPrice = pizzaDto.Price,
                UserName = userDto.Email,
                PizzaId = pizzaDto.Id,
                UserId = userDto.Id
            };

            await _orderRepository.CreateOrder(orderDto);
        }

        public async Task DeleteOrder(OrderDto orderDto)
        {
            await _orderRepository.DeleteOrder(orderDto);
        }
    }
}
