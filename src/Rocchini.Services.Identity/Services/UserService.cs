using Rocchini.Common.Exceptions;
using Rocchini.Services.Identity.Domain.Models;
using Rocchini.Services.Identity.Domain.Repositories;
using Rocchini.Services.Identity.Domain.Services;
using System.Threading.Tasks;

namespace Rocchini.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }
        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
                throw new RocchiniException("invalid_credentials", $"User does not exist");

            if(!user.ValidatePassword(password, _encrypter))
                throw new RocchiniException("invalid_credentials", $"Invalid password supplied");

        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
                throw new RocchiniException("email_in_use", $"This email {email} is already taken for other user");

            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }
    }
}
