using Infraestructure.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Infra.Events.EventBus
{
    public class RabbitPublisherToInventario : IRabbitPublisherToInventario
    {
        private readonly IConnection _connection;

        public RabbitPublisherToInventario(CancellationToken cancellationToken = default)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "pocddd",
                Password = "1983",
                DispatchConsumersAsync = true, // necesario para consumers async
            };

            // NUEVO API async //manejo excepcion!
            _connection = factory.CreateConnection();
        }

        public Task Publish<T>(T evt, CancellationToken cancellationToken = default)
        {
            using var channel = _connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: "products.exchange",
                type: "fanout",
                durable: true);

            var json = JsonSerializer.Serialize(evt);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                exchange: "products.exchange",
                routingKey: "",
                basicProperties: null,
                body: body
            );

            System.Diagnostics.Debug.WriteLine($"[Publisher] Evento enviado a Rabbit → {json}");

            return Task.CompletedTask;
        }
    }
}