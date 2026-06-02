using System.Diagnostics;
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
        novoCliente.Id = clientes.Count + 1;
        clientes.Add(novoCliente);

        return RedirectToAction("Index");
    }


}
