using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Authenticators;
using PizzaStore.WPF.State.Navigators;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;

        public string Email
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public ICommand LoginCommand { get; }

        public ICommand ViewRegisterCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);

            Email = "hubertgad@gmail.com";

            ErrorMessageViewModel = new MessageViewModel();
        }
    }
}