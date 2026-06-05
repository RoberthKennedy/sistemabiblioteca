using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace sistemabiblioteca.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string busca)
    {
        var meuslivros = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "A Arte da Guerra", Autor = "Sun Tzu" },
            new Livro { Id = 2, Titulo = "Guerra e Paz", Autor = "Liev Tolstói" }
        };

        if (!string.IsNullOrEmpty(busca))
        {
            meuslivros = meuslivros
                .Where(l => l.Titulo.Contains(busca, System.StringComparison.OrdinalIgnoreCase) ||
                            l.Autor.Contains(busca, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

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

    [HttpPost]
    public IActionResult Contato(ContatoViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Simulação de envio de mensagem
            TempData["MensagemSucesso"] = "Obrigado! Sua mensagem foi enviada com sucesso e em breve entraremos em contato.";
            return RedirectToAction("Contato");
        }
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
