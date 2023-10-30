
using examen_cl2_dsw1.DbContexts;
using examen_cl2_dsw1.Exceptions;
using examen_cl2_dsw1.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurando el DBContext para usar el SQL Server
var connectionString = builder.Configuration.GetConnectionString("AccountDB");
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(connectionString));

//Configurando la inyeccion de dependencia para ICustomerRepository
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware(typeof(GlobalExceptionHandler));

app.MapControllers();

app.Run();
