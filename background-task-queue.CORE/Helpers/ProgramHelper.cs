using MassTransit;

namespace background_task_queue.CORE.Helpers;

public static class ProgramHelper
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    // Adicionar variavel de ambiente para usuario e senha de rabbitMQ
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });
    }

    public static void SwaggerConfig(WebApplication app)
    {
        // if (!app.Environment.IsDevelopment()) return;

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
    }
}
