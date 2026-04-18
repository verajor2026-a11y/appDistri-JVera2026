import pika
import json

connection = pika.BlockingConnection(
    pika.ConnectionParameters(
        host='localhost',
        port=5672,
        virtual_host='/',
        credentials=pika.PlainCredentials('admin', 'admin')
    )
)

channel = connection.channel()

channel.queue_declare(queue='clienteDireccionEvent', durable=True)

print("🟢 Conectado a RabbitMQ")
print("📡 Escuchando cola: clienteDireccionEvent")
print("⏳ Esperando mensajes...\n")

def callback(ch, method, properties, body):
    data = json.loads(body.decode())

    print("📩 Mensaje recibido:")
    print("ClienteId:", data.get("ClienteId"))
    print("Nombre:", data.get("NombreCompleto"))
    print("Email:", data.get("Email"))
    print("Dirección:", data.get("DireccionCompleta"))
    print("-" * 40)

channel.basic_consume(
    queue='clienteDireccionEvent',
    on_message_callback=callback,
    auto_ack=True
)

channel.start_consuming()