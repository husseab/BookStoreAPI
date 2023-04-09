using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PACKARD BELL\Documents\BookStore.mdf"";Integrated Security=True;Connect Timeout=30";

// Add services to the container.

builder.Services.AddTransient<IBookRepository, BookDatabase>();
builder.Services.AddControllers();
builder.Services.AddDbContext<BookStoreContext>
    (options => options.UseSqlServer(connection));

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

using(var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>();
    // context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

}

app.Run();
