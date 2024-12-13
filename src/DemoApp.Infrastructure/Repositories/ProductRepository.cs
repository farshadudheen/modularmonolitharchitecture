using DemoApp.Domain.Models;
using DemoApp.Infrastructure.Data;
using DemoApp.Infrastructure.Interfaces;

namespace DemoApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoAppDbContext _context;

        public ProductRepository(DemoAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        public Product GetById(int id) => _context.Products.Find(id);

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
