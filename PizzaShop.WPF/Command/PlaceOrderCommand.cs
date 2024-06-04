using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using iTextSharp.text;
 using iTextSharp.text.pdf;
using PizzaShop.Application.DTOs;
using System.Collections.ObjectModel;
using PizzaShop.WPF.VIewModel;

namespace PizzaShop.WPF.Command
{
    class PlaceOrderCommand : BaseCommand
    {

        private readonly CartViewModel _cartViewModel;

        public PlaceOrderCommand(CartViewModel cartViewModel) 
        {
            _cartViewModel = cartViewModel;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
