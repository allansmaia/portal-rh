namespace PortalRH;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Funcionario(string nome, string cargo, decimal salario)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome nao pode ser vazio.");

        if (string.IsNullOrWhiteSpace(cargo))
            throw new ArgumentException("Cargo nao pode ser vazio.");

        if (salario <= 0)
            throw new ArgumentException("Salario deve ser maior que zero.");

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

    public decimal CalcularFerias()
    {
        return Salario + (Salario / 3);
    }
}