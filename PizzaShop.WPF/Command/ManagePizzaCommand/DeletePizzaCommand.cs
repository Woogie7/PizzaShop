using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.ManagePizzaCommand
{
    internal class DeletePizzaCommand : AsyncCommandBase
    {
        private readonly ManagePizzaViewModel _managePizzaViewModel;
        private readonly IPizzaService _pizzaService;

        public DeletePizzaCommand(ManagePizzaViewModel managePizzaViewModel, IPizzaService pizzaService)
        {
            _managePizzaViewModel = managePizzaViewModel;
            _pizzaService = pizzaService;
        }

        public override bool CanExecute(object parameter)
        {
            return _managePizzaViewModel.SelectedPizza != null && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is PizzaDto incomeToDelete)
            {
                _managePizzaViewModel.Pizzas.Remove(incomeToDelete);
                await _pizzaService.DeletePizzaAsync(incomeToDelete);
            }
        }
    }
}
