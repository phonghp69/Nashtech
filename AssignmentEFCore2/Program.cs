using AssignmentEFCore2.Services;
using AssignmentEFCore2.Models;
using AssignmentEFCore2.Responsitory;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductResponsitory, ProductResponsitory>();
builder.Services.AddTransient<ICategoryResponsitory, CategoryResponsitory>();
builder.Services.AddDbContext<ProductContext>(
    options => options.UseSqlServer("Server=DESKTOP-99TEAPR\\DBHERE;Initial Catalog=DBProductStores;Integrated Security=True")
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
