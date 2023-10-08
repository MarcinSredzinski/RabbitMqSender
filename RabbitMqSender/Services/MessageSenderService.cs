using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace RabbitMqSender.Services
{
    public class MessageSenderService
    {

        private readonly string exchangeName = "DemoExchange";
        private readonly string routingKey = "demo-routing-key";
        private readonly string queueName = "DemoQueue";
        private readonly IModel? channel;
        public MessageSenderService()
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@host.docker.internal:5672");
            factory.ClientProvidedName = "Rabbit Sender App";
            IConnection connection = factory.CreateConnection();

            if (connection != null)
            {
                channel = connection.CreateModel();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queueName, false, false, false, null);
                channel.QueueBind(queueName, exchangeName, routingKey, null);
            }
        }

        public void Send()
        {
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hello world");

            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
        }
    }
}