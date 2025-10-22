using EstudoAPIWEB.Data;
using Microsoft.EntityFrameworkCore;
using EstudoAPIWEB.Profiles;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Register AutoMapper using the DI extension and explicit profile type to avoid ambiguous overloads
builder.Services.AddAutoMapper(typeof(FilmeProfile));

builder.Services.AddOpenApi();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
