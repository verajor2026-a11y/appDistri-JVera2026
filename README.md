# Jorge Vera

# Microservicio Subscriber - Facturación

## Descripción

El presente microservicio corresponde a un subscriber desarrollado en Java utilizando Spring Boot, el cual forma parte de una arquitectura distribuida basada en eventos dentro del módulo de Facturación. Su principal responsabilidad es escuchar mensajes provenientes de una cola de RabbitMQ denominada `pedidoEvent` y procesarlos para su posterior almacenamiento en una base de datos PostgreSQL.

Este enfoque permite desacoplar los servicios del sistema, eliminando la necesidad de comunicación directa entre ellos y favoreciendo la escalabilidad y mantenibilidad de la solución.

---

## Conexión a RabbitMQ

El microservicio establece conexión con RabbitMQ mediante la configuración definida en Spring Boot. Se especifican parámetros como host, puerto, usuario y contraseña para acceder al broker de mensajería.

Una vez establecida la conexión, el servicio se suscribe a la cola `pedidoEvent`, permitiendo la recepción automática de mensajes publicados por otros componentes del sistema.

Configuración utilizada:

spring.rabbitmq.host=localhost
spring.rabbitmq.port=5672
spring.rabbitmq.username=guest
spring.rabbitmq.password=guest

---

## Consumo de la cola pedidoEvent

El consumo de mensajes se realiza a través de un listener implementado en la clase `PedidoSubscriber.java`, utilizando la anotación `@RabbitListener`.

Este mecanismo permite que el microservicio escuche continuamente la cola `pedidoEvent`. Cada vez que se recibe un mensaje:

* Se captura automáticamente
* Se interpreta como un objeto en formato JSON
* Se transforma a una entidad Java
* Se procesa para su almacenamiento

Este proceso ocurre de manera asincrónica y automática.

---

## Conexión a PostgreSQL

La conexión a la base de datos PostgreSQL se encuentra configurada en el proyecto mediante Spring Boot. La base de datos se ejecuta en un contenedor Docker, lo que permite su aislamiento y fácil despliegue.

Datos de conexión:

Host: localhost
Puerto: 5434
Usuario: postgres
Password: admin

Configuración aplicada:

spring.datasource.url=jdbc:postgresql://localhost:5434/postgres
spring.datasource.username=postgres
spring.datasource.password=admin
spring.jpa.hibernate.ddl-auto=update

---

## Inserción de datos

Una vez que el microservicio recibe el mensaje desde RabbitMQ, se ejecuta el siguiente flujo:

1. El mensaje es recibido en formato JSON
2. Se convierte en un objeto de tipo Pedido
3. Se validan los datos
4. Se utiliza un repositorio JPA para persistir la información
5. Se inserta el registro en la base de datos PostgreSQL

Este proceso se realiza sin intervención manual, garantizando eficiencia en el manejo de datos.

---

## Estructura de la tabla Pedidos

La tabla `Pedidos` en la base de datos PostgreSQL almacena la información recibida desde la cola.

Campos principales:

* id: Identificador único del pedido
* clienteId: Identificador del cliente
* total: Valor total del pedido
* fecha: Fecha de creación del pedido

Esta estructura permite registrar y gestionar adecuadamente la información necesaria para el módulo de facturación.

---

## Flujo completo del sistema

El flujo de funcionamiento del sistema es el siguiente:

1. Un servicio publica un mensaje en la cola `pedidoEvent` en RabbitMQ
2. El microservicio subscriber escucha la cola de forma constante
3. Al llegar un mensaje, este es recibido automáticamente
4. El mensaje es transformado de JSON a objeto Java
5. Se procesa la información contenida en el mensaje
6. Se establece conexión con la base de datos PostgreSQL
7. Se insertan los datos en la tabla `Pedidos`

Este flujo evidencia una arquitectura basada en eventos, donde los servicios operan de forma desacoplada.

---

## Evidencias

Se adjuntan las siguientes evidencias del funcionamiento del sistema:

* Ejecución del proyecto Spring Boot
* Recepción de mensajes desde RabbitMQ
* <img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/ceecdc42-6643-4f3b-8fa7-f17f28a7075a" />
* Configuración de la cola `pedidoEvent`
* <img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/b5d20685-e178-4f65-90e6-838ad894e02a" />
* Visualización de la tabla `Pedidos` en PostgreSQL Y Registros insertados correctamente en la base de datos
* <img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/0d6170ef-a48a-4ee1-a894-94437906f384" />


---

## Conclusión

El desarrollo de este microservicio permitió comprender el funcionamiento de sistemas distribuidos basados en eventos, destacando el uso de RabbitMQ como mecanismo de comunicación asincrónica.

Se evidenció la importancia de una arquitectura desacoplada para mejorar la escalabilidad y flexibilidad del sistema. Asimismo, se integraron tecnologías como Spring Boot, RabbitMQ y PostgreSQL, fortaleciendo los conocimientos en desarrollo de aplicaciones empresariales modernas.
