namespace Infraestructure.Interfaces
{
    public interface IRabbitPublisher
    {
        Task Publish<T>(T evt, CancellationToken cancellationToken = default);
    }
}
