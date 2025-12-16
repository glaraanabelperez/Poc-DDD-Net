using MediatR;

namespace aplication.Events { 
    public record ProductNotificationInventarioEventModel(long id) : INotification;

    //public record ProductCreatedIntegrationCommandHandler(long id) : INotification;

}