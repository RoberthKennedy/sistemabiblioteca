using Microsoft.AspNetCore.Mvc;
using sistemabiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sistemabiblioteca.Controllers;

public class AdminController : Controller
{

    public static List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Nome = "Dom Casmurro", Descricao = "Obra prima de Machado de Assis.", Preco = 35.00m, Categoria = "Livro" },
        new Produto { Id = 2, Nome = "O Alquimista", Descricao = "Fábula mística de Paulo Coelho.", Preco = 42.90m, Categoria = "Livro" },
        new Produto { Id = 3, Nome = "A Revolução dos Bichos", Descricao = "Clássico de George Orwell sobre política e sociedade.", Preco = 29.90m, Categoria = "Livro" },
        new Produto { Id = 4, Nome = "1984", Descricao = "Distopia de George Orwell sobre vigilância e controle.", Preco = 39.90m, Categoria = "Livro" },
        new Produto { Id = 5, Nome = "O Pequeno Príncipe", Descricao = "Obra de Antoine de Saint-Exupéry sobre amizade e valores.", Preco = 24.90m, Categoria = "Livro" },
        new Produto { Id = 6, Nome = "Capitães da Areia", Descricao = "Romance de Jorge Amado sobre jovens em situação de rua.", Preco = 34.90m, Categoria = "Livro" },
        new Produto { Id = 7, Nome = "Memórias Póstumas de Brás Cubas", Descricao = "Clássico de Machado de Assis narrado por um defunto.", Preco = 37.50m, Categoria = "Livro" },
        new Produto { Id = 8, Nome = "Harry Potter e a Pedra Filosofal", Descricao = "Primeira aventura do jovem bruxo Harry Potter.", Preco = 49.90m, Categoria = "Livro" },
        new Produto { Id = 9, Nome = "Senhor dos Anéis: A Sociedade do Anel", Descricao = "Início da épica jornada criada por Tolkien.", Preco = 59.90m, Categoria = "Livro" },
        new Produto { Id = 10, Nome = "Código Limpo", Descricao = "Guia de boas práticas para desenvolvimento de software.", Preco = 89.90m, Categoria = "Livro" }

    };


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