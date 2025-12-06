using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MapsterMapper;

namespace ProductManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR handlers from this assembly
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        // Register Mapster
        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
