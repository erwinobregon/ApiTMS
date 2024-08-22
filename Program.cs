using ApiTMS.Data;
using ApiTMS.Repository;
using ApiTMS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "APITMS",
        Description = "<strong> API para el el seguimiento y control del pedidos <strong>",
        TermsOfService = new Uri("https://example.com/terms")
    });


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddDbContext<DBTMSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TMS")));
builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.TryAddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.TryAddScoped<IEstadoService, EstadoService>();
builder.Services.TryAddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.TryAddScoped<IPedidoService, PedidoService>();
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
