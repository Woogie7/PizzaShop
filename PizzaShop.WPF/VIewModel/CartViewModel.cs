using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.WPF.Command.CartViewCommand;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    public class CartViewModel : ObservaleObject
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        private int _quantity;

        public int SumQuantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        private decimal _totalAmount;

        public decimal SumTotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public ICommand DeletePizzaInCart { get; }

        public ObservableCollection<OrderDto> Orders => _cartService.Orders;

        public CartViewModel(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;

            IncreaseQuantityCommand = new IncreaseQuantityCommand(_orderService, _cartService);
            DecreaseQuantityCommand = new DecreaseQuantityCommand(_orderService, _cartService);
            DeletePizzaInCart = new DeletePizzaInCart(_orderService, _cartService);

            _cartService.OrdersUpdated += (s, e) => UpdateTotals();

            UpdateTotals();
        }

        public void UpdateTotals()
        {
            SumQuantity = Orders.Sum(order => order.Quantity);
            SumTotalAmount = Orders.Sum(order => order.TotalPrice);
        }
    }

}

