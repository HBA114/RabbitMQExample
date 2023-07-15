using System.Text;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// Creating ConnectionFactory with "HostName = localhost" property
var factory = new ConnectionFactory { HostName = "localhost" };

// Creating connection from factory
using var connection = factory.CreateConnection();

// Creating channel from connection
using var channel = connection.CreateModel();

// Declaration of queue on channel
channel.QueueDeclare(queue: "message-queue", durable: true, exclusive: false, autoDelete: false);

Console.WriteLine("Waiting for messages...");

var consumer = new EventingBasicConsumer(model: channel);

consumer.Received += (model, eventArgs) =>
{
    var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
    Console.WriteLine($"Received Message: {message}");
};

channel.BasicConsume(queue: "message-queue", autoAck: true, consumer: consumer);

Console.WriteLine("Press Enter to Exit!");
Console.ReadLine();
