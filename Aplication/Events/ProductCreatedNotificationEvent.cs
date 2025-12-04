

using MediatR;

namespace Aplication.Events
{
    public record ProductCreatedNotificationEvent(string name, int stock, long desposito, long? id = null) : INotification;

}