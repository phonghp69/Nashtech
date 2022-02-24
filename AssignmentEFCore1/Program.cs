using Microsoft.EntityFrameworkCore;
using AssignmentEFCore1.Models;
using AssignmentEFCore1.Responsitory;
using AssignmentEFCore1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDBContext>(
    options => options.UseSqlServer("Server=DESKTOP-99TEAPR\\DBHERE;Initial Catalog=DBStudent;Integrated Security=True")
);
builder.Services.AddTransient<IResponsitory, StudentResponsitory>();
builder.Services.AddTransient<IServices,Services>();
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
