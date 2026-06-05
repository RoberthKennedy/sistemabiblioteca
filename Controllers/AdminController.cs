using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistemabiblioteca.Controllers;

public class AdminController : Controller
{
    private static List<Produto> _produtos = new List<Produto>();


    public IActionResult Index(string busca)
    {
        var resultado = string.IsNullOrEmpty(busca) ?
            _produtos :
            _produtos.Where(p => p.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase)).ToList();

        return View(resultado);
    }

    public IActionResult Criar() => View();

    [HttpPost]
    public IActionResult Criar(Produto p)
    {
        if (!ModelState.IsValid)
            return View(p);

        p.Id = _produtos.Count + 1;
        _produtos.Add(p);
        return RedirectToAction("Index");
    }

    public IActionResult Editar(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        return View(produto);
    }

    [HttpPost]
    public IActionResult Editar(Produto p)
    {
        if (!ModelState.IsValid)
            return View(p);

        var index = _produtos.FindIndex(x => x.Id == p.Id);
        if (index != -1) _produtos[index] = p;
        return RedirectToAction("Index");
    }

    public IActionResult Excluir(int id)
    {
        _produtos.RemoveAll(p => p.Id == id);
        return RedirectToAction("Index");
    }
}