using PizzaShop.WPF.Command;
using PizzaShop.WPF.Core;
using PizzaShop.WPF.Service;
using PizzaShop.WPF.Service.Store;
using System.Windows.Input;

namespace PizzaShop.WPF.VIewModel
{
    class MainWindowViewModel : ObservaleObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly IAuthenticator _authenticator;
        public ObservaleObject CurrentViewModel => _navigationStore.CurrentViewModel;


        private string _nameUser = string.Empty;

        public string NameUser
        {
            get { return _nameUser; }
            set { 
                _nameUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand PizzaNavigateCommand { get; }


        public MainWindowViewModel(NavigationStore navigationStore,
            NavigationService<PizzaViewModel> pizzaNavigationService
,
            IAuthenticator authenticator)
        {
            _navigationStore = navigationStore;
            _authenticator = authenticator;

            PizzaNavigateCommand = new NavigateCommand<PizzaViewModel>(pizzaNavigationService);

            
            if(_authenticator.CurrentUser != null)
            {
                _nameUser = _authenticator.CurrentUser.UserName;
            }

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
