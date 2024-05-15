using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service.Store;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    class MainWindowViewModel : ObservaleObject
    {
        private readonly NavigationStore _navigationStore;
        public ObservaleObject CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand PizzaNavigateCommand { get; }

        public MainWindowViewModel(NavigationStore navigationStore,
            NavigationService<PizzaViewModel> pizzaNavigationService
            )
        {
            _navigationStore = navigationStore;

            PizzaNavigateCommand = new NavigateCommand<PizzaViewModel>(pizzaNavigationService);
            

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
