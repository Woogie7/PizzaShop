using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Application.Interface;
using PizzaShop.WPF.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PizzaShop.WPF.VIewModel
{
    class ManagePizzaViewModel : ObservaleObject
    {
        private readonly IPizzaService _pizzaService;
        private readonly ISizeService _sizeService;

        public ObservableCollection<PizzaDto> Pizzas { get; set; }
        public ObservableCollection<SizeDto> Sizes { get; set; }


        #region Свойства

        private string name;
        private List<string> ingredients = new List<string>();
        private SizeDto selectedSize;
        private string category;
        private decimal price;
        private string description;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public List<string> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public SizeDto SelectedSize
        {
            get { return selectedSize; }
            set
            {
                selectedSize = value;
                OnPropertyChanged(nameof(SelectedSize));
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


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


        public ManagePizzaViewModel(IPizzaService pizzaService, ISizeService sizeService)
        {
            _pizzaService = pizzaService;
            _sizeService = sizeService;

            Pizzas = new ObservableCollection<PizzaDto>();
            Sizes = new ObservableCollection<SizeDto>();

            LoadPizza();
            LoadSize();
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

        public async Task LoadSize()
        {
            Sizes.Clear();
            var allSize = await _sizeService.GetSizeAllAsync();

            foreach (var size in allSize)
            {
                Sizes.Add(size);
            }
        }
    }
}
