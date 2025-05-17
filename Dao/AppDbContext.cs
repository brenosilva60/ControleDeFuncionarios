using controleDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<DadosBancarios> DadosBancarios { get; set; }   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=controleDeFuncionarios.db");
    }
}