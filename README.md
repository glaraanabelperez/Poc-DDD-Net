
DESARROLLO Y POC EN PROCESO

📘  ## POC – .NET Core | DDD + CQRS + RabbitMQ + EF Core

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/16e7f6ba-81b2-4ef8-87db-ff986f30d296" />



✨ ## Descripción del Proyecto

Este proyecto es una prueba de concepto (POC) orientada a demostrar una arquitectura limpia y escalable usando:

Domain-Driven Design (DDD)

CQRS con MediatR

Mensajería asincrónica con RabbitMQ

Persistencia con Entity Framework Core

.NET 8

Se simula un flujo simple de creación de productos, publicación de eventos y consumo por RabbitMQ.

🏛 Arquitectura General

El proyecto sigue una arquitectura basada en capas limpias:

Dependencias: 

 Api -> Aplication

 Application → Domain

 Infrastructure → Application

 

📦 # Tecnologías Principales

🟣 .NET 8

Framework principal del proyecto.

🟢 CQRS, MediatR

Separación entre comandos y consultas.

Handlers independientes para cada operación.

Registra eventos de dominio y distribuye handlers independientes.

🔵 DDD

Entidades de contexto.

Eventos de Dominio.

Value Objects.


🟠 RabbitMQ en Docker

Comando utilizado para levantar RabbitMQ localmente, en docker desktop
docker run -d --hostname rabbit-local --name rabbit -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=pocddd -e RABBITMQ_DEFAULT_PASS=1983 rabbitmq:3-management


Publicación de Integration Events.


🟠 Aplicacion de consola que consume las notificaciones
https://github.com/glaraanabelperez/Poc-DDD-Net-ConsolaConsumer



🟡 Entity Framework Core

Implementación de repositorios y manejo de eventos externos.

DbContext aislado en Infrastructure.

🔄 Flujo de Ejecución
📌 1. API recibe el comando

El controller recibe un POST /products.

📌 2. Application ejecuta un Command Handler

El Handler:

Valida reglas.

Crea el agregado Product.

Persiste con Repository.

📌 3. Se dispara un Domain Event

ProductCreatedDomainEvent se registra desde el agregado.

📌 4. Application o Infra manejan el evento

Un Notification/Event Handler traduce el evento a:

ProductCreatedIntegrationEvent
y lo publica a RabbitMQ vía IRabbitPublisher.

📌 5. Infraestructura envía el mensaje

La clase RabbitPublisher serializa el evento a JSON y lo envía a la queue configurada.

📌 6. Un Worker (Consumer) lo procesa


🗄 Base de Datos (EF Core)

El DbContext está dentro de Infrastructure/DbContext.

##//

▶️ Cómo Ejecutar
Levantar API ,  RabbitMQ en docker y ejecutar la aplicacion de consola.

https://github.com/glaraanabelperez/Poc-DDD-Net-ConsolaConsumer





🧪 Endpoint de Prueba
Crear producto
POST /products
Content-Type: application/json

{
  "name": "Coca Cola",
  "stock": 10,
  "deposito": "D1"
}


📌 To-Do / Mejoras Futuras

Finalizar persistencia.
Manejo de errores avanzado para Rabbit
Logging con Serilog
Tests unitarios y de integración
Agregar un contexto mas complejo.
