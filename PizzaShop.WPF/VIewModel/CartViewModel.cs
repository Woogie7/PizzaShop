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
        private readonly IOrderService _orderSevice;


        private int _quantity;

        public int SumQuantity
        {
            get 
            { 
                return _quantity; 
            }
            set { 
                _quantity = value; 
                OnPropertyChanged();
            }
        }

        private decimal _totalAmount;

        public decimal SumTotalAmount
        {
            get { return _totalAmount; }
            set { 
                _totalAmount = value;
                OnPropertyChanged();
            }
        }


        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }


        public ObservableCollection<OrderDto> Orders{ get; set; }

        public CartViewModel(IOrderService orderSevice)
        {
            Orders = new ObservableCollection<OrderDto>();

            IncreaseQuantityCommand = new IncreaseQuantityCommand(this);
            DecreaseQuantityCommand = new DecreaseQuantityCommand(this);


            Orders.CollectionChanged += (s, e) => UpdateTotals();

            _orderSevice = orderSevice;

            UpdateTotals();
            LoadOrders();
        }

        private async void LoadOrders()
        {
            Orders.Clear();

            var allOrders = await _orderSevice.GetAllOrderAsync();

            foreach (var order in allOrders)
            {
                Orders.Add(order);
            }

            UpdateTotals();
        }

        public void UpdateTotals()
        {
            SumQuantity = Orders.Sum(order => order.Quantity);
            SumTotalAmount = Orders.Sum(order => order.TotalPrice);
            OnPropertyChanged(nameof(Orders));
        }



    }
}

