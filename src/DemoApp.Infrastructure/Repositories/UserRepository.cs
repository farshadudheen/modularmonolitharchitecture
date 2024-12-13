using DemoApp.Domain.Models;
using DemoApp.Infrastructure.Data;
using DemoApp.Infrastructure.Interfaces;

namespace DemoApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DemoAppDbContext _context;

        public UserRepository(DemoAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(int id) => _context.Users.Find(id);

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
