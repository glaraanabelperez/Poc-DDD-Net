using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "pocddd",
            Password = "1983"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // Declare exchange
        channel.ExchangeDeclare(
            exchange: "products.exchange",
            type: "fanout",
            durable: true);

        // Declare queue
        var queueName = "product-created-ms1";
        channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);

        // Bind queue to exchange
        channel.QueueBind(queue: queueName, exchange: "products.exchange", routingKey: "");

        Console.WriteLine("[Listener] Esperando eventos...");

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);

            var data = JsonSerializer.Deserialize<ProductCreatedIntegrationEvent>(json);

            Console.WriteLine($"[Listener] Evento recibido desde Rabbit:\n{json}");
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        Console.ReadLine();
    }
}

public record ProductCreatedIntegrationEvent(
    Guid ProductId,
    string Name,
    int Stock,
    Guid Deposito
);
