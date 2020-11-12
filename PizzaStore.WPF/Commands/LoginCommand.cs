using PizzaStore.Domain.Exceptions;
using PizzaStore.WPF.State.Authenticators;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;

        private readonly IAuthenticator _authenticator;

        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel,
                            IAuthenticator authenticator,
                            IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _authenticator.LoginAsync(_loginViewModel.Email, _loginViewModel.Password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "User not found.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Username and password does not match.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}