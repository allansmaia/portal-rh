namespace PortalRH;

public class RelatorioRH
{
    public string GerarResumo(List<Departamento> departamentos)
    {
        if (departamentos.Count == 0)
            return string.Empty;

        var resumo = "";

        foreach (var departamento in departamentos)
        {
            resumo += $"Departamento: {departamento.Nome}\n";
            resumo += $"Funcionarios: {departamento.Funcionarios.Count}\n";
            resumo += $"Total folha: R$ {departamento.CalcularFolha():N2}\n\n";
        }

        return resumo.TrimEnd();
    }
}