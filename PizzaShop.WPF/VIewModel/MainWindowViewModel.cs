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

        public bool IsLoggedIn
        {
            get { return _authenticator.IsLoggedIn;}
        }


        public MainWindowViewModel(NavigationStore navigationStore,
            NavigationService<LoginViewModel> loginNavigationService
,
            IAuthenticator authenticator)
        {
            _navigationStore = navigationStore;
            _authenticator = authenticator;

            LoginNavigateCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            LogoutCommand = new LogoutCommand(_authenticator, this);

            
            

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(NameUser));
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
}
