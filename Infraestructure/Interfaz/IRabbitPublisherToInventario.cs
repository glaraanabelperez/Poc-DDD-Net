namespace Infraestructure.Interfaces
{
    public interface IRabbitPublisherToInventario
    {
        Task Publish<T>(T evt, CancellationToken cancellationToken = default);
    }
}
