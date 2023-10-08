using Microsoft.AspNetCore.Mvc;
using RabbitMqSender.Services;

namespace RabbitMqSender.Controllers
{
    public class RabbitSenderController : Controller
    {
        public IActionResult Send()
        {
            MessageSenderService messageSenderService = new MessageSenderService();
            messageSenderService.Send();
            return Ok();
        }      
    }
}