using PizzaShop.WPF.Core;
using PizzaShop.WPF.View;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PizzaShop.WPF.Command
{
    internal class PrintPdfFile : BaseCommand
    {

        public PrintPdfFile()
        {
     
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (parameter is Grid printGrid)
                {
                    Window parentWindow = Window.GetWindow(printGrid);
                    if (parentWindow != null)
                        parentWindow.IsEnabled = false;

                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(printGrid, "invoice");
                    }
                }
            }
            finally
            {
                if (parameter is Grid)
                {
                    Window parentWindow = Window.GetWindow((Grid)parameter);
                    if (parentWindow != null)
                        parentWindow.IsEnabled = true;
                }
            }
        }
    }

}
