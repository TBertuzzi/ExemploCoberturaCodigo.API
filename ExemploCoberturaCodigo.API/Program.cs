using ExemploCoberturaCodigo.Data.Repositories;
using ExemploCoberturaCodigo.Domain.Interfaces.Repositories;
using ExemploCoberturaCodigo.Domain.Interfaces.Services;
using ExemploCoberturaCodigo.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

//Injeção de Dependencia
builder.Services.AddScoped<IComprasRepository, ComprasRepository>();
builder.Services.AddScoped<IComprasService, ComprasService>();

// Add services to the container.
builder.Services.AddControllers();
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
