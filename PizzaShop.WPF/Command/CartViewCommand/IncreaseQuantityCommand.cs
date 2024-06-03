﻿using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.CartViewCommand
{
    internal class IncreaseQuantityCommand : AsyncCommandBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public IncreaseQuantityCommand(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            if (parameter is OrderDto order)
            {
                await _orderService.IncreaseQuantity(order);
                await _cartService.ClearOrders();

            }
        }
    }
}
