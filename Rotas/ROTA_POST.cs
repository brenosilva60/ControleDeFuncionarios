using Microsoft.EntityFrameworkCore;
using controleDeFuncionarios.Models;
using controleDeFuncionarios.Dao;

namespace controleDeFuncionarios.Rotas;

public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        // POST Cargo
        app.MapPost("/api/cargo", async (Cargo cargo, AppDbContext context) =>
        {
            context.Cargos.Add(cargo);
            await context.SaveChangesAsync();
            return Results.Created($"/api/cargo/{cargo.id}", cargo);
        });

        // POST DadosBancarios
        app.MapPost("/api/dadosbancarios", async (DadosBancarios dados, AppDbContext context) =>
        {
            context.DadosBancarios.Add(dados);
            await context.SaveChangesAsync();
            return Results.Created($"/api/dadosbancarios/{dados.id}", dados);
        });

        // POST Endereco
        app.MapPost("/api/endereco", async (Endereco endereco, AppDbContext context) =>
        {
            context.Enderecos.Add(endereco);
            await context.SaveChangesAsync();
            return Results.Created($"/api/endereco/{endereco.Id}", endereco);
        });

        // POST Pessoa
        app.MapPost("/api/pessoa", async (Pessoa pessoa, AppDbContext context) =>
        {
            context.Pessoas.Add(pessoa);
            await context.SaveChangesAsync();
            return Results.Created($"/api/pessoa/{pessoa.id}", pessoa);
        });

        // POST Setor
        app.MapPost("/api/setor", async (Setor setor, AppDbContext context) =>
        {
            context.Setores.Add(setor);
            await context.SaveChangesAsync();
            return Results.Created($"/api/setor/{setor.id}", setor);
        });

        // POST Funcionario
        app.MapPost("/api/funcionario", async (Funcionario funcionario, AppDbContext context) =>
        {
            context.Funcionarios.Add(funcionario);
            await context.SaveChangesAsync();
            return Results.Created($"/api/funcionario/{funcionario.id}", funcionario);
        });
    }
}
