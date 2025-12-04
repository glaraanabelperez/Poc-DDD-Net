using MediatR;

namespace Infraestructure.IntegrationCommand
{
    public record ProductCreatedIntegration(string name, int stock, long desposito, long? id = null);

}