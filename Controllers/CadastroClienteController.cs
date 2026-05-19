using System.Diagnostics;
using biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Controllers;

public class CadastroClienteController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

