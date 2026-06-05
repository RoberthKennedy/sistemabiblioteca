using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;
using System.Collections.Generic;

namespace sistemabiblioteca.Controllers
{
    public class CadastroClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public IActionResult Index()
        {
            return View(clientes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            cliente.Id = clientes.Count + 1;
            clientes.Add(cliente);

            return RedirectToAction("Index");
        }
    }
}