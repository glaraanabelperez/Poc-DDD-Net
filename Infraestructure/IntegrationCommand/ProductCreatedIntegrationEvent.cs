using MediatR;

namespace Infraestructure.IntegrationCommand
{
    public record ProductCreatedIntegrationEvent(string name, int stock, long desposito, long? id = null);

}