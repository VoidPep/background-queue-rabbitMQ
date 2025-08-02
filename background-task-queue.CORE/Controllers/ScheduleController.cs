using background_task_queue.Domain.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace background_task_queue.CORE.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ScheduleController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> AddToQueue([FromQuery] string valor)
    {
        await _publishEndpoint.Publish(new Message(valor, DateTime.Now));
        return Accepted();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Api esta funcionando");
    }
}