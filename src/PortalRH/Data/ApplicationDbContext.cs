using Microsoft.EntityFrameworkCore;

namespace PortalRH.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Funcionario> Funcionarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Salario).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Nome = "Ana Silva", Cargo = "Desenvolvedora", Salario = 5000m, DataAdmissao = new DateTime(2023, 1, 15) },
            new Funcionario { Id = 2, Nome = "Carlos Lima", Cargo = "Analista", Salario = 4000m, DataAdmissao = new DateTime(2023, 3, 20) },
            new Funcionario { Id = 3, Nome = "Maria Costa", Cargo = "Gerente", Salario = 8000m, DataAdmissao = new DateTime(2022, 6, 10) },
            new Funcionario { Id = 4, Nome = "Pedro Souza", Cargo = "Designer", Salario = 4500m, DataAdmissao = new DateTime(2023, 5, 5) },
            new Funcionario { Id = 5, Nome = "Julia Ferreira", Cargo = "Desenvolvedora", Salario = 5500m, DataAdmissao = new DateTime(2023, 2, 1) },
            new Funcionario { Id = 6, Nome = "Rafael Oliveira", Cargo = "DevOps", Salario = 6000m, DataAdmissao = new DateTime(2022, 11, 15) },
            new Funcionario { Id = 7, Nome = "Fernanda Santos", Cargo = "Scrum Master", Salario = 7000m, DataAdmissao = new DateTime(2022, 8, 1) },
            new Funcionario { Id = 8, Nome = "Lucas Mendes", Cargo = "Analista de QA", Salario = 4200m, DataAdmissao = new DateTime(2023, 4, 10) },
            new Funcionario { Id = 9, Nome = "Beatriz Rocha", Cargo = "Product Owner", Salario = 7500m, DataAdmissao = new DateTime(2022, 9, 20) },
            new Funcionario { Id = 10, Nome = "Thiago Alves", Cargo = "Arquiteto", Salario = 9000m, DataAdmissao = new DateTime(2021, 12, 1) }
        );
    }
}
