using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalRH.Web.Services;
using PortalRH;

namespace PortalRH.Web.Controllers;

[Authorize]
public class FuncionarioController : Controller
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    public IActionResult Index()
    {
        var funcionarios = _funcionarioService.ObterTodos();
        return View(funcionarios);
    }

    public IActionResult Detalhes(int id)
    {
        var funcionario = _funcionarioService.ObterPorId(id);
        if (funcionario == null)
            return NotFound();
        return View(funcionario);
    }

    [HttpGet]
    public IActionResult Novo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Novo(string nome, string cargo, decimal salario)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cargo) || salario <= 0)
        {
            ViewBag.Erro = "Preencha todos os campos corretamente.";
            return View();
        }

        var funcionario = new Funcionario(nome, cargo, salario);
        _funcionarioService.Adicionar(funcionario);
        return RedirectToAction("Index");
    }
}