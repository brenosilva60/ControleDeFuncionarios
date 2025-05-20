using controleDeFuncionarios.Models;
using controleDeFuncionarios.Dao;
using controleDeFuncionarios.Rotas;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

InicializarBanco.PopularBancoDeDados(app.Services);

app.MapGet("/", () => "Hello World!");
app.MapGetRoutes();
app.MapPostRoutes();
app.MapDeleteRoutes();

app.Run();
