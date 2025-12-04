
namespace Domain.Events
{
    public record ProductCreatedDomainEvent(string name, int stock, long desposito, long? id = null) : IDomainEvent;
}