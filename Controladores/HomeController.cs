using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BackendLearningHub.Modelos;
using BackendLearningHub.Servicos;

namespace BackendLearningHub.Controladores;

public class HomeController : Controller
{
    private readonly RepositorioAprendizado _repository;

    public HomeController(RepositorioAprendizado repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        var aulas = _repository.ObterAulas();
        ViewBag.TotalAulas = aulas.Count;
        ViewBag.TotalUnidades = _repository.ObterUnidades().Count;
        return View(aulas.Take(6).ToList());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErroViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
