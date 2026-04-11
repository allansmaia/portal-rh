using PortalRH;

namespace PortalRH.Tests;

public class DepartamentoTests
{
    [Fact]
    public void Departamento_DeveSerCriadoComNomeCorreto()
    {
        var departamento = new Departamento("Tecnologia");

        Assert.Equal("Tecnologia", departamento.Nome);
    }

    [Fact]
    public void Departamento_DeveIniciarComListaVazia()
    {
        var departamento = new Departamento("RH");

        Assert.Empty(departamento.Funcionarios);
    }

    [Fact]
    public void AdicionarFuncionario_DeveIncluirFuncionarioNaLista()
    {
        var departamento = new Departamento("Tecnologia");
        var funcionario = new Funcionario("Ana Silva", "Desenvolvedora", 5000m);

        departamento.AdicionarFuncionario(funcionario);

        Assert.Single(departamento.Funcionarios);
        Assert.Equal("Ana Silva", departamento.Funcionarios[0].Nome);
    }
    [Fact]
    public void CalcularFolha_SemFuncionarios_DeveRetornarZero()
    {
        var departamento = new Departamento("Tecnologia");

        var total = departamento.CalcularFolha();

        Assert.Equal(0m, total);
    }

    [Fact]
    public void CalcularFolha_ComUmFuncionario_DeveRetornarSalario()
    {
        var departamento = new Departamento("Tecnologia");
        departamento.AdicionarFuncionario(new Funcionario("Ana Silva", "Desenvolvedora", 5000m));

        var total = departamento.CalcularFolha();

        Assert.Equal(5000m, total);
    }

    [Fact]
    public void CalcularFolha_ComMultiplosFuncionarios_DeveRetornarSoma()
    {
        var departamento = new Departamento("Tecnologia");
        departamento.AdicionarFuncionario(new Funcionario("Ana Silva", "Desenvolvedora", 5000m));
        departamento.AdicionarFuncionario(new Funcionario("Carlos Lima", "Analista", 4000m));

        var total = departamento.CalcularFolha();

        Assert.Equal(9000m, total);
    }
}