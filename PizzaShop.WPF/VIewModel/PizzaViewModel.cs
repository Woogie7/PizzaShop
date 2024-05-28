﻿using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    class PizzaViewModel : ObservaleObject
    {
        private readonly IPizzaService _pizzaService;
        private readonly IAuthenticator _authenticator;

        public ObservableCollection<PizzaDto> Pizzas { get; set; }
        public ICollectionView PizzaCollectionView { get; }
        
        private string _pizzaFilter = string.Empty;
        public string PizzaFilter
        {
            get { return _pizzaFilter; }
            set
            {
                _pizzaFilter = value;
                OnPropertyChanged(nameof(PizzaFilter));
                PizzaCollectionView.Refresh();
            }
        }

        private bool _isAdmin = false;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
        public ICommand AddPizzaCommand { get;}


        public PizzaViewModel(IPizzaService pizzaService, IAuthenticator authenticator, NavigationService<ManagePizzaViewModel> navigateCommand)
        {
            _authenticator = authenticator;
            _pizzaService = pizzaService;
            Pizzas = new ObservableCollection<PizzaDto>();
            PizzaCollectionView = CollectionViewSource.GetDefaultView(Pizzas);

            AddPizzaCommand = new NavigateCommand<ManagePizzaViewModel>(navigateCommand);

            PizzaCollectionView.Filter = FillterPizzas;
            PizzaCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(PizzaDto.Name)));

            LoadPizza();
            CheckAdminRole();
        }

        private void CheckAdminRole()
        {
            if(_authenticator.CurrentUser != null)
            {
                var currentUser = _authenticator.CurrentUser;
                IsAdmin = currentUser.Role.Name.Contains("Admin");
            }
        }

        private bool FillterPizzas(object obj)
        {
            if (obj is PizzaDto pizza)
            {
                return pizza.Name.Contains(PizzaFilter, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
        public async Task LoadPizza()
        {
            Pizzas.Clear();
            var adllPizzas = await _pizzaService.GetPizzaAllAsync();

            Pizzas.Add(new PizzaDto { Name = "Маргарита", Ingredients = new[] { "Соус", "Сыр", "Базилик" }, Size = "Средняя", Category = "Классические", Price = 250, Description = "Классическая и всегда популярная пицца с соусом, сыром и базиликом.", ImageSource = "/Images/Pizza1.jpg" });
            Pizzas.Add(new PizzaDto { Name = "Пепперони", Ingredients = new[] { "Соус", "Сыр", "Пепперони" }, Size = "Большая", Category = "Мясные", Price = 300, Description = "Сытная пицца с острой колбасой пепперони.", ImageSource = "/Images/Pizza2.jpg" });
            Pizzas.Add(new PizzaDto { Name = "Гавайская", Ingredients = new[] { "Соус", "Сыр", "Ветчина", "Ананасы" }, Size = "Средняя", Category = "Фруктовые", Price = 280, Description = "Нежная и сладкая пицца с ветчиной и ананасами.", ImageSource = "/Images/Pizza3.jpg" });
            Pizzas.Add(new PizzaDto { Name = "Новая", Ingredients = new[] { "Соус", "Сыр", "Ветчина", "Ананасы" }, Size = "Средняя", Category = "Фруктовые", Price = 280, Description = "Нежная и сладкая пицца с ветчиной и ананасами.", ImageSource = "/Images/Pizza4.jpg" });

            foreach (var income in adllPizzas)
            {
                Pizzas.Add(income);
            }
        }
    }
}
