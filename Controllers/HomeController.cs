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
            new Livro { Id = 2, Titulo = "Guerra e Paz", Autor = "Liev Tolstói" },
            new Livro { Id = 3, Titulo = "Nada de Novo no Front", Autor = "Erich Maria Remarque" },
            new Livro { Id = 4, Titulo = "Stalingrado", Autor = "Antony Beevor" },
            new Livro { Id = 5, Titulo = "A Segunda Guerra Mundial", Autor = "Winston Churchill" },
            new Livro { Id = 6, Titulo = "Tempestade de Aço", Autor = "Ernst Jünger" },
            new Livro { Id = 7, Titulo = "Band of Brothers", Autor = "Stephen E. Ambrose" },
            new Livro { Id = 8, Titulo = "A Guerra Não Tem Rosto de Mulher", Autor = "Svetlana Alexievich" },
            new Livro { Id = 9, Titulo = "O Diário de Anne Frank", Autor = "Anne Frank" },
            new Livro { Id = 10, Titulo = "Pearl Harbor", Autor = "Craig Nelson" },
            new Livro { Id = 11, Titulo = "A Queda de Berlim 1945", Autor = "Antony Beevor" },
            new Livro { Id = 11, Titulo = "Sobre a Guerra", Autor = "Carl von Clausewitz" },
            new Livro { Id = 12, Titulo = "Os Canhões de Agosto", Autor = "Barbara W. Tuchman" },
            new Livro { Id = 13, Titulo = "O Longo Caminho para Casa", Autor = "Ernest Hemingway" },
            new Livro { Id = 14, Titulo = "A Grande Guerra", Autor = "Marc Ferro" },
            new Livro { Id = 15, Titulo = "A Guerra do Peloponeso", Autor = "Tucídides" },
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

    public IActionResult Produtos(string busca)
    {

        var listaParaVenda = AdminController._produtos;

        if (!string.IsNullOrEmpty(busca))
        {
            listaParaVenda = listaParaVenda.Where(p => p.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase) || p.Descricao.Contains(busca, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        return View(listaParaVenda);
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
