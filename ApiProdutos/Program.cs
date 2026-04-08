var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers();

var app = builder.Build();

// Pipeline
app.UseHttpsRedirection();

app.MapControllers();

app.Run();