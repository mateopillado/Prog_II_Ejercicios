<<<<<<< HEAD
using ApiTurno.Models;
using ApiTurno.Repository;
using ApiTurno.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

=======
>>>>>>> 506acc96fd2103906ea70dc95b04c7db12b4712b
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddDbContext<turnos_dbContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped< ITurnoRepository, TurnoRepository>(); //crea una nueva instancia por cada request
builder.Services.AddScoped<ITurnoService, TurnoService>();

=======
>>>>>>> 506acc96fd2103906ea70dc95b04c7db12b4712b
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
<<<<<<< HEAD

//pasos 
//    crear proyecto
//    instalar nuget
//    ing inversa, de la bd traer con orm todas las clases
//    inyectar el contexto en el program
//    crear los repositorios con interfaces y implementaciones (con cada nuevo repositorio se inyecta en el program)
//    llamar al servicio desde la api
=======
>>>>>>> 506acc96fd2103906ea70dc95b04c7db12b4712b
