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
}