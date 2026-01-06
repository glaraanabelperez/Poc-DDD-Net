
DESARROLLO Y POC EN PROCESO

📘  ## POC – .NET Core | DDD + CQRS + RabbitMQ + EF Core

![ddd](https://github.com/user-attachments/assets/7b4f56ba-93c6-40e6-9745-fe4aa3d48be6)



✨ ## Descripción del Proyecto

Este proyecto es una prueba de concepto (POC) orientada a demostrar una arquitectura limpia y escalable usando:

-Arquitectura de Microservicios
-Metodologia Domain-Driven Design (DDD)

-Patron de responsabilidad: CQRS para la separacion Commands/Querys.
-Patron de comportamiento: MediatR, para publicar la creacion de producto a la capa de  a infra y asi realizar la persistencia en la BBDD.
-Patron de comunicacion: Mensajería asincrónica con RabbitMQ, para la notificacion al MS Almacen

Se simula un flujo simple de creación de productos, consulta a otros MS por llamada http, publicación de eventos, envio de mensaje usando RabbitMQ de forma basica y consumo por consola, en otro POC.
Varios desarrollos estan sin realizar. Ubicadas e indicadas en cada capa y proyecto correspondiente con comentarios, para segmentarlo en diferentes tareas. 


🏛 ## Arquitectura General

El proyecto sigue una arquitectura basada en capas limpias:

Dependencias: 

 Api -> Aplication

 Application → Domain

 Infrastructure → Application


 

📦 # Tecnologías Principales

🟣 .NET 8, EF, Sql Server, RabbitMQ, librerias .Net

##//

▶️ Cómo Ejecutar
1- Levantar API.
2- INSTALAR Imagen de RabbitMQ en docker 
3 -Levantar Consumidor :
* Aplicacion de consola que consume las notificaciones
https://github.com/glaraanabelperez/Poc-DDD-Net-ConsolaConsumer

Docker
Comando utilizado para levantar RabbitMQ localmente, en docker desktop
docker run -d --hostname rabbit-local --name rabbit -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=pocddd -e RABBITMQ_DEFAULT_PASS=1983 rabbitmq:3-management


