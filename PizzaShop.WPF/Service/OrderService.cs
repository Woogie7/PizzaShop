using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface.Repository;
using PizzaShop.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShop.Application.DTOs;

namespace PizzaShop.WPF.Service
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }
    }
}
