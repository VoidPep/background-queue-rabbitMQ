using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace background_task_queue.CORE.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ScheduleController> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public ScheduleController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] string valor)
    {
        // await _publishEndpoint.Publish(new Message(valor, DateTime.Now));
        return Accepted();
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Api esta funcionando");
    }
}