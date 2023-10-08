using RabbitMQ.Client;

namespace RabbitMqSender.Services
{
    public class MessageSenderService
    {
        public MessageSenderService()
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("anqp://guest:guest@localhost:5672");
        }
    }
}
