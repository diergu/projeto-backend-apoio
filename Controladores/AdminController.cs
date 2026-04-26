using BackendLearningHub.Modelos;
using BackendLearningHub.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendLearningHub.Controladores;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly RepositorioAprendizado _repository;

    public AdminController(RepositorioAprendizado repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        ViewBag.Unidades = _repository.ObterUnidades(includeUnpublished: true);
        return View(_repository.ObterAulas(includeUnpublished: true));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CriarAula(Aula aula)
    {
        if (string.IsNullOrWhiteSpace(aula.Titulo) || string.IsNullOrWhiteSpace(aula.Resumo))
        {
            TempData["Message"] = "Preencha titulo e resumo da aula.";
            return RedirectToAction(nameof(Index));
        }

        _repository.AdicionarAula(aula);
        TempData["Message"] = "Aula cadastrada com sucesso.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AlternarPublicacao(int aulaId)
    {
        _repository.AlternarPublicacao(aulaId);
        return RedirectToAction(nameof(Index));
    }
}
