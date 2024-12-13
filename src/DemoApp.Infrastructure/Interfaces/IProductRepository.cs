using DemoApp.Domain.Models;

namespace DemoApp.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
    }

}
