using PC_Club.Shared.Exceptions;
using PC_Club.Models;
using PC_Club.Repositories;

namespace PC_Club.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = userRepository.Get(userCredentials.login);
            bool isValid = user != null && AreValidCredentials(userCredentials, user);

            if (!isValid)
            {
                throw new InvalidCredentialsException();
            }
        }

        private static bool AreValidCredentials(UserCredentials userCredentials, User user)
        {
            return user.login == userCredentials.login &&
                   user.password == userCredentials.password;
        }
    }
}
