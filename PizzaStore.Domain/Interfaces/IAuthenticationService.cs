using PizzaStore.Domain.Models;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public enum RegistrationResult
    {
        Success, PasswordDoNotMatch, EmailAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> RegisterAsync(string email, string name, string password, string confirmPassword);

        Task<User> LoginAsync(string email, string password);
    }
}