using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
Console.WriteLine(connectionString);
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB URI");
    Environment.Exit(0);
}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
