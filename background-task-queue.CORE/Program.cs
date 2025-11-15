using background_task_queue.CORE.Helpers;

var builder = WebApplication.CreateBuilder(args);

ProgramHelper.AddServices(builder);

var app = builder.Build();

ProgramHelper.SwaggerConfig(app);

app.UseAuthorization();
app.MapControllers();
app.Run();
