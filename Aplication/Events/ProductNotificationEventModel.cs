using MediatR;

namespace aplication.Events {
    //o iNotification
    public record ProductNotificationEventModel(long id, int stock): INotification;
}