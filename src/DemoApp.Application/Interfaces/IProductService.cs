using DemoApp.Domain.Models;

namespace DemoApp.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(string name, decimal price);
    }
}
