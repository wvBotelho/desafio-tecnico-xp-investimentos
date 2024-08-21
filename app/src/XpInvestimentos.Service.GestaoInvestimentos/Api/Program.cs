using Api.Middlewares;
using Core.Interfaces;
using Hangfire;
using IOC.InjectionDependency;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterMongoDb(config);

builder.Services.RegisterAutomapper();

builder.Services.RegisterApplicationServices(config);

builder.Services.RegisterHangFire();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

IEmailDeliveryService service = app.Services.GetService<IEmailDeliveryService>()!;

RecurringJob.AddOrUpdate("daily-email-job", () => service.SendDailyNotification(), Cron.Daily);

app.Run();
