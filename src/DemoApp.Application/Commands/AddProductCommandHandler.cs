using DemoApp.Domain.Exceptions;
using DemoApp.Domain.Models;
using DemoApp.Infrastructure.Interfaces;
using MediatR;

namespace DemoApp.Application.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || request.Price <= 0)
            {
                throw new OutOfStockException("Invalid product details.");
            }

            var product = new Product { Name = request.Name, Price = request.Price };
            _repository.Add(product);

            return Unit.Value; // Use Unit.Value to satisfy IRequestHandler when no return type is needed
        }
    }
}
