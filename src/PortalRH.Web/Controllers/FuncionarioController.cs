using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalRH.Web.Services;
using PortalRH;

namespace PortalRH.Web.Controllers;

[Authorize]
public class FuncionarioController : Controller
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioController(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index(string? busca, string? cargo)
    {
        var funcionarios = await _repository.BuscarAsync(busca, cargo);
        
        ViewBag.Busca = busca;
        ViewBag.CargoSelecionado = cargo;
        ViewBag.Cargos = await _repository.ObterTodosAsync()
            .ContinueWith(t => t.Result.Select(f => f.Cargo).Distinct().OrderBy(c => c).ToList());
        
        return View(funcionarios);
    }

    public async Task<IActionResult> Detalhes(int id)
    {
        var funcionario = await _repository.ObterPorIdAsync(id);
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Novo([Bind("Nome,Cargo,Salario,DataAdmissao")] Funcionario funcionario)
    {
        if (ModelState.IsValid)
        {
            await _repository.AdicionarAsync(funcionario);
            TempData["Sucesso"] = "Funcionario cadastrado com sucesso!";
            return RedirectToAction("Index");
        }
        return View(funcionario);
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var funcionario = await _repository.ObterPorIdAsync(id);
        if (funcionario == null)
            return NotFound();
        return View(funcionario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, [Bind("Id,Nome,Cargo,Salario,DataAdmissao")] Funcionario funcionario)
    {
        if (id != funcionario.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            await _repository.AtualizarAsync(funcionario);
            TempData["Sucesso"] = "Funcionario atualizado com sucesso!";
            return RedirectToAction("Index");
        }
        return View(funcionario);
    }

    [HttpGet]
    public async Task<IActionResult> Deletar(int id)
    {
        var funcionario = await _repository.ObterPorIdAsync(id);
        if (funcionario == null)
            return NotFound();
        return View(funcionario);
    }

    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmarDelecao(int id)
    {
        await _repository.RemoverAsync(id);
        TempData["Sucesso"] = "Funcionario removido com sucesso!";
        return RedirectToAction("Index");
    }
}