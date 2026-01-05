using MediatR;

namespace aplication.Events {
    public record ProductNotificationEventModel(long id, int stock): INotification;
}