using Microsoft.EntityFrameworkCore;
using ToDoApi.Infrastructure;
using System.Text.Json.Serialization;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Repositories;
using ToDoApi.Application.Interfaces;
using ToDoApi.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:80");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseInMemoryDatabase("ToDoDb"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
