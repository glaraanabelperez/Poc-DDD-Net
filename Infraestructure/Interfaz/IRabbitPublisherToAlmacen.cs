namespace Infraestructure.Interfaces
{
    public interface IRabbitPublisherToAlmacen
    {
        Task Publish<T>(T evt, CancellationToken cancellationToken = default);
    }
}
