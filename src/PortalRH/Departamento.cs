namespace PortalRH;

public class Departamento
{
    public string Nome { get; set; }
    public List<Funcionario> Funcionarios { get; set; }

    public Departamento(string nome)
    {
        Nome = nome;
        Funcionarios = new List<Funcionario>();
    }

    public void AdicionarFuncionario(Funcionario funcionario)
    {
        Funcionarios.Add(funcionario);
    }

    public decimal CalcularFolha()
    {
        decimal total = 0;
        foreach (var funcionario in Funcionarios)
        {
            total += funcionario.Salario;
        }
        return total;
    }
}