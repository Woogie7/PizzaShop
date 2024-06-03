using PizzaShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Application.Interface
{
    public interface ICartService
    {
        ObservableCollection<OrderDto> Orders { get; }

        event EventHandler OrdersUpdated;

        void AddOrder(OrderDto order);
        Task ClearOrders();
        void RemoveOrder(OrderDto order);
    }
}
