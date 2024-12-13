using DemoApp.Application.Interfaces;
using DemoApp.Application.Services;
using DemoApp.Infrastructure.Interfaces;
using DemoApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.SharedKernel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
