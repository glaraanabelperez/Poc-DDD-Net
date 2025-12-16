using Aplication.Interfaces;
using Aplication.IRepository;
using Domain.Repository;
using Infra.Events.EventBus;
using Infraestructure.Querys;
using Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionInfra
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRabbitPublisher, RabbitPublisher>();
        //dbContext
        return services;
    }
}
