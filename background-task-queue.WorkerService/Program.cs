using MassTransit;
using WorkerService;
using WorkerService.Consumers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("queue", e =>
        {
            e.ConfigureConsumer<MessageConsumer>(context);
        });
    });
});

var host = builder.Build();
host.Run();