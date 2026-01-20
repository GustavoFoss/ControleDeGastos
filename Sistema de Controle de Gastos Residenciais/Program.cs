using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Gastos_Residenciais.Application.Services;
using Sistema_de_Controle_de_Gastos_Residenciais.Infrastructure.Data;
using SistemaDeControleDeGastosResidenciais.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// CONFIGURAÇÕES DE SERVIÇOS
// ==========================

// Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection - Services
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<TransacaoService>();

var app = builder.Build();

// ==========================
// CONFIGURAÇÕES DO PIPELINE
// ==========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
