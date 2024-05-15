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

        public string TextTest { get; set; }
        public PizzaViewModel(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;

            Pizzas = new ObservableCollection<PizzaDto>();
            TextTest = "Хуесос";

            LoadPizza();


            Pizzas.Add(new PizzaDto { Name = "Маргарита", Ingredients = new[] { "Соус", "Сыр", "Базилик" }, Size = "Средняя", Category = "Классические", Price = 250, Description = "Классическая и всегда популярная пицца с соусом, сыром и базиликом." });
            Pizzas.Add(new PizzaDto { Name = "Пепперони", Ingredients = new[] { "Соус", "Сыр", "Пепперони" }, Size = "Большая", Category = "Мясные", Price = 300, Description = "Сытная пицца с острой колбасой пепперони." });
            Pizzas.Add(new PizzaDto { Name = "Гавайская", Ingredients = new[] { "Соус", "Сыр", "Ветчина", "Ананасы" }, Size = "Средняя", Category = "Фруктовые", Price = 280, Description = "Нежная и сладкая пицца с ветчиной и ананасами." });
            Pizzas.Add(new PizzaDto { Name = "Новая", Ingredients = new[] { "Соус", "Сыр", "Ветчина", "Ананасы" }, Size = "Средняя", Category = "Фруктовые", Price = 280, Description = "Нежная и сладкая пицца с ветчиной и ананасами." });
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
