using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infrastructure.Repositories;

namespace ProductManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<ICategoryRepository, InMemoryCategoryRepository>();
        return services;
    }
}
