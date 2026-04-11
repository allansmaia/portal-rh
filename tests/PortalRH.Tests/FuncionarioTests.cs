using PortalRH;

namespace PortalRH.Tests;

public class FuncionarioTests
{
    [Fact]
    public void CalcularBonus_DeveRetornarValorCorreto()
    {
        var funcionario = new Funcionario("Ana Silva", "Desenvolvedora", 5000m);

        var bonus = funcionario.CalcularBonus(10);

        Assert.Equal(500m, bonus);
    }

    [Fact]
    public void CalcularBonus_PercentualNegativo_DeveLancarExcecao()
    {
        var funcionario = new Funcionario("Carlos Lima", "Analista", 4000m);

        var ex = Record.Exception(() => funcionario.CalcularBonus(-5));
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void Funcionario_DeveTerPropriedadesCorretas()
    {
        var funcionario = new Funcionario("Maria Costa", "Gerente", 8000m);

        Assert.Equal("Maria Costa", funcionario.Nome);
        Assert.Equal("Gerente", funcionario.Cargo);
        Assert.Equal(8000m, funcionario.Salario);
    }
    [Fact]
    public void Funcionario_NomeVazio_DeveLancarExcecao()
    {
        var ex = Record.Exception(() => new Funcionario("", "Desenvolvedor", 5000m));
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void Funcionario_CargoVazio_DeveLancarExcecao()
    {
        var ex = Record.Exception(() => new Funcionario("Ana Silva", "", 5000m));
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void Funcionario_SalarioZero_DeveLancarExcecao()
    {
        var ex = Record.Exception(() => new Funcionario("Ana Silva", "Desenvolvedora", 0m));
        Assert.IsType<ArgumentException>(ex);
    }
}