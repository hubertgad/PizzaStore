using Microsoft.AspNet.Identity;
using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.AuthenticationServices
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

        public async Task RegisterAsync(string email, string name, string password, string confirmPassword)
        {
            if (Regex.IsMatch(email, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?") == false)
            {
                throw new InputNotValidException("Email is not valid.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new InputNotValidException("Name cannot be empty.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new InputNotValidException("Password cannot be empty.");
            }

            if (password != confirmPassword)
            {
                throw new InputNotValidException("Passwords does not match.");
            }

            User emailUser = await _userService.GetByEmailAsync(email);

            if (emailUser != null)
            {
                throw new InputNotValidException("This e-mail is already taken.");
            }

            User user = new User(email, name, _passwordHasher.HashPassword(password));
            await _userService.CreateAsync(user);
        }
    }
}