using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.WPF.VIewModel
{
    class PizzaViewModel : ObservaleObject
    {
        private readonly IPizzaService _pizzaService;

        public ObservableCollection<PizzaDto> Pizzas { get; set; }
        public PizzaViewModel(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;

            Pizzas = new ObservableCollection<PizzaDto>();

            LoadPizza();
        }

        public async Task LoadPizza()
        {
            Pizzas.Clear();
            var adllPizzas = await _pizzaService.GetPizzaAllAsync();

            foreach (var income in adllPizzas)
            {
                Pizzas.Add(income);
            }
        }
    }
}
