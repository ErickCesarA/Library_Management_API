global using Microsoft.EntityFrameworkCore;
global using Library_ManagementAPI.Models;
global using Library_ManagementAPI.Data;
using Library_ManagementAPI.Services.BookSevice;
using Library_ManagementAPI.Services.GenresService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddCors(options => options.AddPolicy(name: "BookOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("BookOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
