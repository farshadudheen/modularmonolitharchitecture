using MediatR;

namespace DemoApp.Application.Commands
{
    public record AddProductCommand(string Name, decimal Price) : IRequest<Unit>;
}
