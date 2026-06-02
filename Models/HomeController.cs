using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var meuslivros = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "A Arte da Guerra", Autor = "Sun Tzu" },
            new Livro { Id = 2, Titulo = "Guerra e Paz", Autor = "Liev Tolstói" }
        };
        return View(meuslivros);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult Produtos()
    {
        return View();
    }

    public IActionResult Contato()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
