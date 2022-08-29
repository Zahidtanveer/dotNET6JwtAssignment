using DotNET6JwtAssignment.API.Extensions;
using DotNET6JwtAssignment.API.Middleware;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureMapping();

// logging using elasticsearch
LoggingMiddleware.ConfigureLogging();
builder.Host.UseSerilog();

builder.Services.ConfigurePostgreSQL(builder.Configuration);
builder.Services.ConfigureUnitOfWork();

builder.Services.RegisterValidationServices();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.ConfigureControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

