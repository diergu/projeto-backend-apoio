using BackendLearningHub.Modelos;
using BackendLearningHub.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendLearningHub.Controladores;

[Authorize]
public class CursosController : Controller
{
    private readonly RepositorioAprendizado _repository;

    public CursosController(RepositorioAprendizado repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? string.Empty;
        var completed = _repository.ObterUsuarioPorEmail(email)?.IdsAulasConcluidas ?? [];
        var aulas = _repository.ObterAulas();
        var model = new PainelCursoViewModel
        {
            Unidades = _repository.ObterUnidades(),
            IdsAulasConcluidas = completed,
            AulasPublicadas = aulas.Count,
            PercentualConclusao = aulas.Count == 0 ? 0 : (int)Math.Round(completed.Count * 100m / aulas.Count)
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AlternarProgresso(int aulaId)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? string.Empty;
        _repository.AlternarProgresso(email, aulaId);
        return RedirectToAction(nameof(Index));
    }
}
