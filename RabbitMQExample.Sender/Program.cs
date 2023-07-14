using System.Text;

using RabbitMQ.Client;

// Creating ConnectionFactory with "HostName = localhost" property
var factory = new ConnectionFactory { HostName = "localhost" };

// Creating connection from factory
using var connection = factory.CreateConnection();

// Creating channel from connection
using var channel = connection.CreateModel();

// Declaration of queue on channel
channel.QueueDeclare(queue: "message-queue", durable: true, exclusive: false, autoDelete: false);

// Creating message
var message = "VBT RabbitMQ Example";

// Converting message to byte array for sending
var body = Encoding.UTF8.GetBytes(message);

// Publishing message in channel
channel.BasicPublish(exchange: String.Empty, routingKey: "message-queue", basicProperties: null, body: body);

Console.WriteLine("Message sent to queue!");
