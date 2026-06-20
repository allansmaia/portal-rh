using PortalRH;

namespace PortalRH.Web.Services;

public class DashboardViewModel
{
    public int TotalFuncionarios { get; set; }
    public int TotalDepartamentos { get; set; }
    public decimal TotalFolha { get; set; }
    public decimal MediaSalarial { get; set; }
    public string MaiorSalarioNome { get; set; } = "—";
    public decimal MaiorSalario { get; set; }
    public List<CargoCount> FuncionariosPorCargo { get; set; } = new();
    public Funcionario? NovoFuncionario { get; set; }
}

public class DashboardService
{
    private readonly IFuncionarioRepository _repository;

    public DashboardService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardViewModel> ObterResumoAsync()
    {
        var funcionarios = await _repository.ObterTodosAsync();
        var maiorSalario = funcionarios.OrderByDescending(f => f.Salario).FirstOrDefault();
        var stats = await _repository.ObterEstatisticasAsync();

        return new DashboardViewModel
        {
            TotalFuncionarios = funcionarios.Count,
            TotalDepartamentos = 3,
            TotalFolha = stats.FolhaPagamento,
            MediaSalarial = stats.MediaSalarial,
            MaiorSalarioNome = maiorSalario?.Nome ?? "—",
            MaiorSalario = maiorSalario?.Salario ?? 0,
            FuncionariosPorCargo = stats.FuncionariosPorCargo,
            NovoFuncionario = funcionarios.OrderByDescending(f => f.DataAdmissao).FirstOrDefault()
        };
    }
}