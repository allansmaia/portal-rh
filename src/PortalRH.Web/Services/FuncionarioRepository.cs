using Microsoft.EntityFrameworkCore;
using PortalRH.Data;

namespace PortalRH.Web.Services;

public interface IFuncionarioRepository
{
    Task<List<Funcionario>> ObterTodosAsync();
    Task<List<Funcionario>> BuscarAsync(string? nome, string? cargo);
    Task<Funcionario?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Funcionario funcionario);
    Task AtualizarAsync(Funcionario funcionario);
    Task RemoverAsync(int id);
    Task<DashboardStats> ObterEstatisticasAsync();
}

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly ApplicationDbContext _context;

    public FuncionarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Funcionario>> ObterTodosAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    public async Task<List<Funcionario>> BuscarAsync(string? nome, string? cargo)
    {
        var query = _context.Funcionarios.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome))
        {
            query = query.Where(f => f.Nome.ToLower().Contains(nome.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(cargo) && cargo != "Todos")
        {
            query = query.Where(f => f.Cargo == cargo);
        }

        return await query.ToListAsync();
    }

    public async Task<Funcionario?> ObterPorIdAsync(int id)
    {
        return await _context.Funcionarios.FindAsync(id);
    }

    public async Task AdicionarAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario != null)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<DashboardStats> ObterEstatisticasAsync()
    {
        var funcionarios = await _context.Funcionarios.ToListAsync();
        
        var stats = new DashboardStats
        {
            TotalFuncionarios = funcionarios.Count,
            FolhaPagamento = funcionarios.Sum(f => f.Salario),
            MediaSalarial = funcionarios.Count > 0 ? funcionarios.Average(f => f.Salario) : 0,
            FuncionariosPorCargo = funcionarios
                .GroupBy(f => f.Cargo)
                .Select(g => new CargoCount { Cargo = g.Key, Quantidade = g.Count() })
                .OrderByDescending(c => c.Quantidade)
                .ToList()
        };

        return stats;
    }
}

public class DashboardStats
{
    public int TotalFuncionarios { get; set; }
    public decimal FolhaPagamento { get; set; }
    public decimal MediaSalarial { get; set; }
    public List<CargoCount> FuncionariosPorCargo { get; set; } = new();
}

public class CargoCount
{
    public string Cargo { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}
