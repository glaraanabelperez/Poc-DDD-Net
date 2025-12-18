using Aplication.IRepository;
using Infra.Events.EventBus;
using Infraestructure.Interfaces;
using Infraestructure.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionInfra
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRabbitPublisherToInventario, RabbitPublisherToInventario>();
        //dbContext
        return services;
    }
}
