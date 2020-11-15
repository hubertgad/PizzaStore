using PizzaStore.Domain.Models;
using System;
using System.Threading.Tasks;

namespace PizzaStore.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }

        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task RegisterAsync(string email, string name, string password, string confirmPassword);

        Task LoginAsync(string email, string password);

        void Logout();
    }
}