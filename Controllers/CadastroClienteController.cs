using System.Diagnostics;
using biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Controllers;

public class CadastroClienteController : Controller
{
    private static List<Cliente> clientes = new List<Cliente>();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Cadastrar(Cliente novoCliente)
    {
        novocliente.Id = clientes.Count + 1;
        clientes.Add(novocliente);

        return RedirectToAction("Index");
    }


}

