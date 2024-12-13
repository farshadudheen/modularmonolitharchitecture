using DemoApp.Domain.Models;

namespace DemoApp.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(string name, string email);
    }

}
