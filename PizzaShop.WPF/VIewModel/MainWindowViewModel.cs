using PizzaShop.Application.Interface;
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
        private readonly ManagePizzaViewModel _managePizzaViewModel;
        private readonly IOrderService orderService;

        private bool _isCartVisible;
        public bool IsCartVisible
        {
            get { return _isCartVisible; }
            set
            {
                _isCartVisible = value;
                OnPropertyChanged(nameof(IsCartVisible));
            }
        }
        public ObservaleObject CurrentViewModel => _navigationStore.CurrentViewModel;



        public string NameUser
        {
            get { return _authenticator.CurrentUser?.UserName; }
            set {
                _authenticator.CurrentUser.UserName = value;
                OnPropertyChanged(nameof(NameUser));
            }
        }

        public ICommand LoginNavigateCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ToggleCartCommand { get; }

        public bool IsLoggedIn
        {
            get { return _authenticator.IsLoggedIn;}
        }

        public CartViewModel CartViewModel { get; }


        public MainWindowViewModel(NavigationStore navigationStore,
            NavigationService<LoginViewModel> loginNavigationService
,
            IAuthenticator authenticator,
            ManagePizzaViewModel managePizzaViewModel,
            IOrderService orderService)
        {
            _navigationStore = navigationStore;
            _authenticator = authenticator;

            LoginNavigateCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            ToggleCartCommand = new ToggleCartCommand(this);


            this.orderService = orderService;
            CartViewModel = new CartViewModel(orderService);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _managePizzaViewModel = managePizzaViewModel;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(NameUser));
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
}
