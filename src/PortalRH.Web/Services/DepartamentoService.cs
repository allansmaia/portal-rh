using PortalRH;

namespace PortalRH.Web.Services;

public class DepartamentoService
{
    private readonly List<Departamento> _departamentos = new();

    public DepartamentoService()
    {
        var ti = new Departamento("Tecnologia");
        ti.AdicionarFuncionario(new Funcionario("Ana Silva", "Desenvolvedora", 5000m));
        ti.AdicionarFuncionario(new Funcionario("Julia Ferreira", "Desenvolvedora", 5500m));
        ti.AdicionarFuncionario(new Funcionario("Rafael Oliveira", "DevOps", 6000m));
        ti.AdicionarFuncionario(new Funcionario("Thiago Alves", "Arquiteto", 9000m));

        var rh = new Departamento("Recursos Humanos");
        rh.AdicionarFuncionario(new Funcionario("Maria Costa", "Gerente", 8000m));
        rh.AdicionarFuncionario(new Funcionario("Fernanda Santos", "Scrum Master", 7000m));

        var produto = new Departamento("Produto");
        produto.AdicionarFuncionario(new Funcionario("Beatriz Rocha", "Product Owner", 7500m));
        produto.AdicionarFuncionario(new Funcionario("Pedro Souza", "Designer", 4500m));

        var qualidade = new Departamento("Qualidade");
        qualidade.AdicionarFuncionario(new Funcionario("Lucas Mendes", "Analista de QA", 4200m));
        qualidade.AdicionarFuncionario(new Funcionario("Carlos Lima", "Analista", 4000m));

        _departamentos.Add(ti);
        _departamentos.Add(rh);
        _departamentos.Add(produto);
        _departamentos.Add(qualidade);
    }

    public List<Departamento> ObterTodos() => _departamentos.ToList();

    public Departamento? ObterPorNome(string nome) =>
        _departamentos.FirstOrDefault(d => d.Nome == nome);

    public void Adicionar(Departamento departamento) => _departamentos.Add(departamento);
}