using PortalRH;

namespace PortalRH.Web.Services;

public class FuncionarioService
{
    private readonly List<Funcionario> _funcionarios = new();

    public FuncionarioService()
    {
        Adicionar(new Funcionario("Ana Silva", "Desenvolvedora", 5000m));
        Adicionar(new Funcionario("Carlos Lima", "Analista", 4000m));
        Adicionar(new Funcionario("Maria Costa", "Gerente", 8000m));
        Adicionar(new Funcionario("Pedro Souza", "Designer", 4500m));
        Adicionar(new Funcionario("Julia Ferreira", "Desenvolvedora", 5500m));
        Adicionar(new Funcionario("Rafael Oliveira", "DevOps", 6000m));
        Adicionar(new Funcionario("Fernanda Santos", "Scrum Master", 7000m));
        Adicionar(new Funcionario("Lucas Mendes", "Analista de QA", 4200m));
        Adicionar(new Funcionario("Beatriz Rocha", "Product Owner", 7500m));
        Adicionar(new Funcionario("Thiago Alves", "Arquiteto", 9000m));
    }

    public List<Funcionario> ObterTodos() => _funcionarios.ToList();

    public Funcionario? ObterPorId(int id) => _funcionarios.ElementAtOrDefault(id - 1);

    public void Adicionar(Funcionario funcionario) => _funcionarios.Add(funcionario);
}