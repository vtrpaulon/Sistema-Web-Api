using ApiProdutos.Services;
using ApiProdutos.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

// Pipeline
app.UseHttpsRedirection();

app.MapControllers();

app.Run();