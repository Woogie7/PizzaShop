using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Application.Interface;
using PizzaShop.Domain.Entities;
using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    class ManagePizzaViewModel : ObservaleObject
    {
        private readonly IPizzaService _pizzaService;
        private readonly ISizeService _sizeService;
        private readonly ICategorySevice _categoryService;
        private readonly IIngredientService _ingredientSevice;

        public ObservableCollection<PizzaDto> Pizzas { get; set; }
        public ObservableCollection<SizeDto> Sizes { get; set; }
        public ObservableCollection<CategoryDto> Categories { get; set; }
        public ObservableCollection<IngredientDto> Ingredients { get; set; }
        public ObservableCollection<IngredientDto> PizzaIngredients { get; set; }


        #region Свойства

        private string name;
        private IngredientDto selectedIngredient;
        private SizeDto selectedSize;
        private CategoryDto selectedCategory;
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

        public IngredientDto SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
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

        public CategoryDto SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(CategoryDto));
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


        public ICommand AddIngredientCommand { get; set; }

        public ManagePizzaViewModel(IPizzaService pizzaService, ISizeService sizeService, ICategorySevice categoryService, IIngredientService ingredientSevice)
        {
            _pizzaService = pizzaService;
            _sizeService = sizeService;
            _categoryService = categoryService;
            _ingredientSevice = ingredientSevice;

            Pizzas = new ObservableCollection<PizzaDto>();
            Sizes = new ObservableCollection<SizeDto>();
            Categories = new ObservableCollection<CategoryDto>();
            Ingredients = new ObservableCollection<IngredientDto>();
            PizzaIngredients = new ObservableCollection<IngredientDto>();

            AddIngredientCommand = new AddIngredientCommand(this);

            LoadPizza();
            LoadSize();
            LoadCategory();
            LoadIngredient();
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

        public async Task LoadCategory()
        {
            Categories.Clear();
            var allCategories = await _categoryService.GetCategoryAllAsync();

            foreach (var category in allCategories)
            {
                Categories.Add(category);
            }
        }

        public async Task LoadIngredient()
        {
            Ingredients.Clear();
            var allLoadIngredient = await _ingredientSevice.GetIngredientAllAsync();

            foreach (var ingredient in allLoadIngredient)
            {
                Ingredients.Add(ingredient);
            }
        }

    }
}
