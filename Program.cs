using Escola.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//conectando o BD

//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Escola;User ID=root;Password=123456789"));
//Banco Local
//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Escola;User ID=root;Password=123456789"));

// Banco Azure
builder.Services.AddDbContext<EscolaContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(@"Server=tcp:escola-projetocodinggirls.database.windows.net,1433;Initial Catalog=Escola;Persist Security Info=False;User ID=admCodingGirls;Password=Projeto22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

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
