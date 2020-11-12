using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Services.AuthenticationServices;
using PizzaStore.WPF.State.Authenticators;
using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using System.Threading.Tasks;

namespace PizzaStore.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public RegisterCommand(RegisterViewModel registerViewModel,
                               IAuthenticator authenticator,
                               IRenavigator renavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult result = await _authenticator
                    .RegisterAsync(_registerViewModel.Email,
                                   _registerViewModel.Name,
                                   _registerViewModel.Password,
                                   _registerViewModel.ConfirmPassword);

                switch (result)
                {
                    case RegistrationResult.Success:
                        _renavigator.Renavigate();
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "This e-mail is already taken.";
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Passwords does not match.";
                        break;
                    default:
                        break;
                }
            }
            catch (DbUpdateException)
            {
                _registerViewModel.ErrorMessage = "Registration failed.";
            }
        }
    }
}