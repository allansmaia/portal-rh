using System.ComponentModel.DataAnnotations;

namespace PortalRH.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Usuario e obrigatorio.")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha e obrigatoria.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; } = string.Empty;

    public string? ErroLogin { get; set; }
}