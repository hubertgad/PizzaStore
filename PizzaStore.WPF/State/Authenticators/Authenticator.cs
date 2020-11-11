using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace PizzaStore.WPF.State.Authenticators
{
    class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private User _currentUser;

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            private set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;

        public async Task LoginAsync(string email, string password)
        {
            CurrentUser = await _authenticationService.LoginAsync(email, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public Task<RegistrationResult> RegisterAsync(string email, string name, string password, string confirmPassword)
        {
            return _authenticationService.RegisterAsync(email, name, password, confirmPassword);
        }
    }
}