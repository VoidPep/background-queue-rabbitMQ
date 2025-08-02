using background_task_queue.Domain.Contracts;
using MassTransit;

namespace WorkerService.Consumers;

public class MessageConsumer(ILogger logger) : IConsumer<Message>
{
    public async Task Consume(ConsumeContext<Message> context)
    {
        logger.Log(LogLevel.Information, $"[x] Recebido: {context.Message.Value}");
        
        await Task.Delay(10_000);
        
        logger.Log(LogLevel.Information, $"[\u2714] Finalizado: {context.Message.Value}");
    }
}
