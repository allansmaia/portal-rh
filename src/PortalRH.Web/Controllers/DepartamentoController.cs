using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalRH.Web.Services;
using PortalRH;

namespace PortalRH.Web.Controllers;

[Authorize]
public class DepartamentoController : Controller
{
    private readonly DepartamentoService _departamentoService;

    public DepartamentoController(DepartamentoService departamentoService)
    {
        _departamentoService = departamentoService;
    }

    public IActionResult Index()
    {
        var departamentos = _departamentoService.ObterTodos();
        return View(departamentos);
    }

    [HttpGet]
    public IActionResult Novo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Novo(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            ViewBag.Erro = "Informe o nome do departamento.";
            return View();
        }

        var departamento = new Departamento(nome);
        _departamentoService.Adicionar(departamento);
        return RedirectToAction("Index");
    }
}