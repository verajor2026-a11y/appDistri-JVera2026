# Jorge Vera

# Dockerización de Microservicios

## Introducción

Docker es una plataforma que permite empaquetar aplicaciones junto con todas sus dependencias en contenedores. Esto facilita su despliegue, portabilidad y ejecución en diferentes entornos sin problemas de configuración.

El uso de Docker permite que los microservicios funcionen de manera independiente, asegurando consistencia entre entornos de desarrollo y producción.

---

## Microservicios dockerizados

Durante esta actividad se dockerizaron los siguientes microservicios:

### .NET Core

* API Cliente
* API DireccionCliente

### Python

* API Pedidos
* Subscriber RabbitMQ

### Java Spring Boot

* API Facturación
* Subscriber RabbitMQ

---

## Dockerfile por servicio

### .NET Core (API Cliente / API DireccionCliente)

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY . .
EXPOSE 5000
ENTRYPOINT ["dotnet", "ApiCliente.dll"]
```

---

### Python (API Pedidos)

```dockerfile
FROM python:3.10
WORKDIR /app
COPY . .
RUN pip install -r requirements.txt
EXPOSE 8000
CMD ["python", "main.py"]
```

---

### Python (Subscriber RabbitMQ)

```dockerfile
FROM python:3.10
WORKDIR /app
COPY . .
RUN pip install -r requirements.txt
CMD ["python", "subscriber.py"]
```

---

### Java Spring Boot (API Facturación)

```dockerfile
FROM openjdk:17
WORKDIR /app
COPY target/app.jar app.jar
EXPOSE 8080
ENTRYPOINT ["java","-jar","app.jar"]
```

---

### Java Spring Boot (Subscriber RabbitMQ)

```dockerfile
FROM openjdk:17
WORKDIR /app
COPY target/app.jar app.jar
ENTRYPOINT ["java","-jar","app.jar"]
```

---

## Ejecución de contenedores

Construcción de imágenes:

```bash
docker build -t api-cliente .
docker build -t api-pedidos .
docker build -t api-facturacion .
```

Ejecución de contenedores:

```bash
docker run -d -p 5000:5000 api-cliente
docker run -d -p 8000:8000 api-pedidos
docker run -d -p 8080:8080 api-facturacion
```

Ver contenedores activos:

```bash
docker ps
```

---

## Configuración

### Variables de entorno

Se configuraron variables para la conexión a base de datos y RabbitMQ:

* DB_HOST=localhost

* DB_PORT=5432

* DB_USER=postgres

* DB_PASSWORD=admin

* RABBITMQ_HOST=localhost

* RABBITMQ_PORT=5672

---

### Puertos utilizados

* API Cliente: 5000
* API Pedidos: 8000
* API Facturación: 8080

---

### Conexiones

* PostgreSQL para almacenamiento de datos
* RabbitMQ para mensajería entre microservicios

---

## docker-compose.yml (Opcional)

```yaml
version: '3.8'

services:
  postgres:
    image: postgres:alpine
    environment:
      POSTGRES_PASSWORD: admin
    ports:
      - "5434:5432"

  rabbitmq:
    image: rabbitmq:3-management
    ports:
      - "5672:5672"
      - "15672:15672"

  api-cliente:
    build: ./api-cliente
    ports:
      - "5000:5000"
    depends_on:
      - postgres

  api-pedidos:
    build: ./api-pedidos
    ports:
      - "8000:8000"
    depends_on:
      - postgres
      - rabbitmq

  api-facturacion:
    build: ./api-facturacion
    ports:
      - "8080:8080"
    depends_on:
      - postgres
      - rabbitmq
```

---

## Evidencias

Se incluyen las siguientes capturas:

* Dockerfile de cada servicio
* Proceso de construcción de imágenes
* Contenedores en ejecución (`docker ps`)
* Pruebas de APIs funcionando
* Logs de ejecución

---

## Conclusión

La dockerización de los microservicios permitió comprender cómo empaquetar aplicaciones de forma independiente, asegurando su portabilidad y facilidad de despliegue.

Se evidenció la importancia de Docker en arquitecturas modernas, permitiendo ejecutar múltiples servicios de manera organizada y eficiente. Además, se logró integrar tecnologías como .NET, Python y Java dentro de un mismo entorno mediante contenedores.
