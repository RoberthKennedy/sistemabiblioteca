using Microsoft.AspNetCore.Mvc;

namespace sistemabiblioteca.Controllers;

public class AccountController : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        // Lógica de autenticação simplificada
        if (email == "admin@admin.com" && senha == "123")
            return RedirectToAction("Index", "Admin");

        ViewBag.Erro = "Usuário ou senha inválidos";
        return View();
    }

    public IActionResult Registrar() => View();

    [HttpPost]
    public IActionResult Registrar(string nome, string email, string senha) => RedirectToAction("Login");
}