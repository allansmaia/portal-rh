using PortalRH;

namespace PortalRH.Web.Services;

public class DashboardViewModel
{
    public int TotalFuncionarios { get; set; }
    public int TotalDepartamentos { get; set; }
    public decimal TotalFolha { get; set; }
    public string MaiorSalarioNome { get; set; } = "—";
    public decimal MaiorSalario { get; set; }
}

public class DashboardService
{
    private readonly FuncionarioService _funcionarioService;
    private readonly DepartamentoService _departamentoService;

    public DashboardService(FuncionarioService funcionarioService, DepartamentoService departamentoService)
    {
        _funcionarioService = funcionarioService;
        _departamentoService = departamentoService;
    }

    public DashboardViewModel ObterResumo()
    {
        var funcionarios = _funcionarioService.ObterTodos();
        var departamentos = _departamentoService.ObterTodos();

        var maiorSalario = funcionarios.OrderByDescending(f => f.Salario).FirstOrDefault();

        return new DashboardViewModel
        {
            TotalFuncionarios = funcionarios.Count,
            TotalDepartamentos = departamentos.Count,
            TotalFolha = funcionarios.Sum(f => f.Salario),
            MaiorSalarioNome = maiorSalario?.Nome ?? "—",
            MaiorSalario = maiorSalario?.Salario ?? 0
        };
    }
}