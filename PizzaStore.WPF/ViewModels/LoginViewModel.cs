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

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, renavigator);

            Email = "hubertgad@gmail.com";
        }
    }
}