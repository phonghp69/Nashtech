
using Back_end.Models;
using Back_end.DBContext;
using Back_end.Services;
using Back_end.Entities;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IService<User>, UserService>();
builder.Services.AddTransient<IService<Book>, BookService>();
builder.Services.AddTransient<IService<Category>, CategoryService>();
builder.Services.AddTransient<IService<BookBorrowingRequest>, RequestService>();
builder.Services.AddTransient<IService<BookBorrowingRequestDetails>, RequestDetailsService>();

builder.Services.AddDbContext<LibraryDbContext>(
    options => options.UseSqlServer("Server=DESKTOP-99TEAPR\\DBHERE;Initial Catalog=LibraryDB;Integrated Security=True")
    );
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
