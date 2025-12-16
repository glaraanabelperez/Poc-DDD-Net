namespace Domain.Events
{
    public interface IDomainEvent
    {
        public Task Publisher(ProductCreatedNotificationModel eventIntegrated);
    }
}