using AutoMarketProject.Application;
using AutoMarketProject.Infrastructure;
using AutoMarketProject.WebApi.Infrastructure;
using AutoMarketProject.WebApi.Mapping;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalErrorHandling>();
builder.Services.AddProblemDetails();
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddMapping();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseSerilogRequestLogging();

await app.AddMigrationAsync();

app.Run();
