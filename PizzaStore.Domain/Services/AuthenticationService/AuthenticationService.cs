using Microsoft.AspNet.Identity;
using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDataService _userService;

        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserDataService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            User storedUser = await _userService.GetByEmailAsync(email);

            if (storedUser == null)
            {
                throw new UserNotFoundException(email);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }

            return storedUser;
        }

        public async Task<RegistrationResult> RegisterAsync(string email, string name, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return RegistrationResult.PasswordDoNotMatch;
            }

            User emailUser = await _userService.GetByEmailAsync(email);

            if (emailUser != null)
            {
                return RegistrationResult.EmailAlreadyExists;
            }

            User user = new User(email, name, _passwordHasher.HashPassword(password));
            await _userService.CreateAsync(user);

            return RegistrationResult.Success;
        }
    }
}