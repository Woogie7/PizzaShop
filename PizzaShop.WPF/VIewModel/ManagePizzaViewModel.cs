using PizzaShop.Application.DTOs;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    class ManagePizzaViewModel : ObservaleObject
    {
        private readonly IPizzaService _pizzaService;

        public ObservableCollection<PizzaDto> Pizzas { get; set; }


        #region Хуета

        private PizzaDto selectedPizza;

      

        public PizzaDto SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value;
                OnPropertyChanged(nameof(SelectedPizza));
            }
        }

        #endregion


        public ManagePizzaViewModel(IPizzaService pizzaService)
        {
            _pizzaService= pizzaService;
            
            Pizzas = new ObservableCollection<PizzaDto>();

            LoadPizza();


        }

        public async Task LoadPizza()
        {
            Pizzas.Clear();
            var allPizza = await _pizzaService.GetPizzaAllAsync();

            foreach (var pizza in allPizza)
            {
                Pizzas.Add(pizza);
            }
        }
    }
}
