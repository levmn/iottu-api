using IottuBusiness;
using IottuData;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var baseConnection = builder.Configuration.GetConnectionString("DefaultConnection");

var connectionString = $"User Id={dbUser};Password={dbPassword};{baseConnection}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<AntenaService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<PatioService>();
builder.Services.AddScoped<StatusService>();
// builder.Services.AddSingleton<MotoService>(); // Para testar a API com dados em memória

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
