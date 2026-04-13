using ApiProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers();
builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

// Pipeline
app.UseHttpsRedirection();

app.MapControllers();

app.Run();