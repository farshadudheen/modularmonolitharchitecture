using DemoApp.Application.Interfaces;
using DemoApp.Domain.Exceptions;
using DemoApp.Domain.Models;
using DemoApp.Infrastructure.Interfaces;

namespace DemoApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers() => _repository.GetAll();

        public User GetUserById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new InvalidUserException($"User with ID {id} not found.");
            }
            return user;
        }

        public void CreateUser(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidUserException("Name and email are required.");
            }

            var user = new User { Name = name, Email = email };
            _repository.Add(user);
        }
    }
}
