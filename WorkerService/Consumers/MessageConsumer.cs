using background_task_queue.Domain.Contracts;
using MassTransit;

namespace WorkerService.Consumers;

public class MessageConsumer : IConsumer<Message>
{
    public async Task Consume(ConsumeContext<Message> context)
    {
        Console.WriteLine($"[x] Recebido: {context.Message.Value}");
        
        await Task.Delay(5000);
        
        Console.WriteLine($"[✔] Finalizado: {context.Message.Value}");
    }
}
