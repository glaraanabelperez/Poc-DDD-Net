using Aplication.Interfaces;
using Domain.Repository;
using Infra.Events.EventBus;
using Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionInfra
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IRepository, ProductRepository>();
        services.AddScoped<IRabbitPublisher, RabbitPublisher>();
        //dbContext
        return services;
    }
}
