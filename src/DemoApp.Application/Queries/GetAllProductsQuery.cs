using DemoApp.Domain.Models;
using MediatR;

namespace DemoApp.Application.Queries
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
}
