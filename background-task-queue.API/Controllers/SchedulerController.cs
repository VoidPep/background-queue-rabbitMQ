using background_task_queue.Domain.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace background_task_queue.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulerController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public SchedulerController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] string valor)
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