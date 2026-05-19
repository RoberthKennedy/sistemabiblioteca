using System.Diagnostics;
using biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var meuslivros = new List<Livro>();
        {
            new Livro { Id = 1, Titulo "Heroi das mil faces", Autor = "Joseph Campebell" }
        new Livro { Id = 2, Titulo "O codigo da vinci", Autor = "Dan Brown" }
        }
        ;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
