using System.Text;

using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "message-queue", durable: true, exclusive: false, autoDelete: false);

var message = "VBT RabbitMQ Example";

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: String.Empty, routingKey: "message-queue", basicProperties: null, body: body);

Console.WriteLine("Message sent to queue!");
