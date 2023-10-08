using Microsoft.AspNetCore.Mvc;
using RabbitMqSender.Services;

namespace RabbitMqSender.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RabbitSenderController : Controller
{   
    [HttpGet]
    public IActionResult Send()
    {
        MessageSenderService messageSenderService = new MessageSenderService();
        messageSenderService.Send();
        return Ok();
    }      
}