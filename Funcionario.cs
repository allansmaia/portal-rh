namespace PortalRH;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Funcionario(string nome, string cargo, decimal salario)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
    }

    public decimal CalcularBonus(decimal percentual)
    {
        if (percentual < 0)
            throw new ArgumentException("Percentual nao pode ser negativo.");

        return Salario * (percentual / 100);
    }
}