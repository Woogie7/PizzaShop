using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.Command.ManagePizzaCommand
{
    internal class AddNewPizzaCommand : AsyncCommandBase
    {
        private readonly ManagePizzaViewModel _managePizzaViewModel;
        private readonly IPizzaService _pizzaService;

        public AddNewPizzaCommand(ManagePizzaViewModel managePizzaViewModel, IPizzaService pizzaService)
        {
            _managePizzaViewModel = managePizzaViewModel;
            _pizzaService = pizzaService;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if(_managePizzaViewModel.SelectedPizza == null)
            {
                CreatePizzaDto newPizza = new CreatePizzaDto()
                {
                    Name = _managePizzaViewModel.Name,
                    CategoryId = _managePizzaViewModel.SelectedCategory.Id,
                    Description = _managePizzaViewModel.Description,
                    IngredientsId = _managePizzaViewModel.PizzaIngredients.Select(i => i.Id).ToArray(),
                    SizeId = _managePizzaViewModel.SelectedSize.Id,
                    Price = _managePizzaViewModel.Price
                };
                await _pizzaService.AddPizzaAsync(newPizza);
            }
            else
            {
                UpdatePizzaDto newPizza = new UpdatePizzaDto()
                {
                    Id = _managePizzaViewModel.SelectedPizza.Id,
                    Name = _managePizzaViewModel.Name,
                    CategoryId = _managePizzaViewModel.SelectedCategory.Id,
                    Description = _managePizzaViewModel.Description,
                    IngredientsId = _managePizzaViewModel.PizzaIngredients.Select(i => i.Id).ToArray(),
                    SizeId = _managePizzaViewModel.SelectedSize.Id,
                    Price = _managePizzaViewModel.Price
                };

                await _pizzaService.UpdatePizzaAsync(newPizza);
            }


            await _managePizzaViewModel.LoadPizza();

            _managePizzaViewModel.PizzaIngredients = null;
            _managePizzaViewModel.Name = string.Empty;
            _managePizzaViewModel.SelectedCategory = null;
            _managePizzaViewModel.SelectedIngredient = null;
            _managePizzaViewModel.SelectedSize = null;
            _managePizzaViewModel.Price = 0;
            _managePizzaViewModel.Description = null;

        }
    }
}
