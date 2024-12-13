using DemoApp.Domain.Models;

namespace DemoApp.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
    }
}
