using Microsoft.EntityFrameworkCore;
using ContactInfoCRUD.Infrastructure.Data;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Infrastructure.Repositories;
using ContactInfoCRUD.Application.Services;
using ContactInfoCRUD.Application.Handlers;
using AutoMapper;
using Microsoft.OpenApi.Models;
using ContactInfoCRUD.Application.DTOs;
using MediatR;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuración de DbContext
builder.Services.AddDbContext<ContactInfoDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositorios
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaContactoRepository, PersonaContactoRepository>();

// Registro de servicios
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaContactoService, PersonaContactoService>();


// Configuración de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<GetPersonasByCedulaQueryHandler>();
});



// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactInfo API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactInfo API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
