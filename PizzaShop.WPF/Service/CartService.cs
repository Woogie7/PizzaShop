using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Service
{
    public class CartService : ICartService
    {
        private readonly IOrderService _orderSevice;

        public CartService(IOrderService orderSevice)
        {
            _orderSevice = orderSevice;
        }

        public ObservableCollection<OrderDto> Orders { get; private set; } = new ObservableCollection<OrderDto>();

        public event EventHandler OrdersUpdated;

        public void AddOrder(OrderDto order)
        {
            Orders.Add(order);
            OrdersUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveOrder(OrderDto order)
        {
            Orders.Remove(order);
            OrdersUpdated?.Invoke(this, EventArgs.Empty);
        }

        public async Task ClearOrders()
        {
            Orders.Clear();

            var allOrders = await _orderSevice.GetAllOrderAsync();

            foreach (var order in allOrders)
            {
                Orders.Add(order);
            }

            OrdersUpdated?.Invoke(this, EventArgs.Empty);
        }
    }

}
