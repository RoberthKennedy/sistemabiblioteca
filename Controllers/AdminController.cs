using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemabiblioteca.Data;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Controllers;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string busca)
    {
        var produtos = await _context.Produtos
            .Where(p => string.IsNullOrEmpty(busca) || p.Nome.Contains(busca))
            .ToListAsync();

        return View(produtos);
    }

    public IActionResult Criar() => View();

    [HttpPost]
    public async Task<IActionResult> Criar(Produto p)
    {
        if (!ModelState.IsValid)
            return View(p);

        _context.Produtos.Add(p);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return NotFound();
        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Produto p)
    {
        if (!ModelState.IsValid)
            return View(p);

        _context.Produtos.Update(p);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Excluir(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}