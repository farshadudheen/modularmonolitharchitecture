using DemoApp.Application.Interfaces;
using DemoApp.Domain.Exceptions;
using DemoApp.Domain.Models;
using DemoApp.Domain.Rules;
using DemoApp.Infrastructure.Interfaces;

namespace DemoApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProducts() => _repository.GetAll();

        public Product GetProductById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                throw new OutOfStockException($"Product with ID {id} not found.");
            }
            return product;
        }

        public void AddProduct(string name, decimal price)
        {
            if (!ProductRules.IsPriceValid(price))
            {
                throw new OutOfStockException("Invalid product price.");
            }

            var product = new Product { Name = name, Price = price };
            _repository.Add(product);
        }
    }
}
