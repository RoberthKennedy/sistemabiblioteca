using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sistemabiblioteca.Models;

namespace sistemabiblioteca.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Aplica migrações pendentes automaticamente
        await context.Database.MigrateAsync();

        // --- Seed: Role de Administrador ---
        const string adminRole = "Admin";
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        // --- Seed: Usuário Administrador ---
        const string adminEmail = "admin@admin.com";
        const string adminSenha = "Admin@123";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var resultado = await userManager.CreateAsync(adminUser, adminSenha);
            if (resultado.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }

        // --- Seed: Produtos iniciais (só adiciona se o banco estiver vazio) ---
        if (!await context.Produtos.AnyAsync())
        {
            var produtos = new List<Produto>
            {
                new() { Nome = "Dom Casmurro",                         Descricao = "Obra prima de Machado de Assis.",                                    Preco = 35.00m,  Categoria = "Livro" },
                new() { Nome = "O Alquimista",                         Descricao = "Fábula mística de Paulo Coelho.",                                     Preco = 42.90m,  Categoria = "Livro" },
                new() { Nome = "A Revolução dos Bichos",               Descricao = "Clássico de George Orwell sobre política e sociedade.",               Preco = 29.90m,  Categoria = "Livro" },
                new() { Nome = "1984",                                 Descricao = "Distopia de George Orwell sobre vigilância e controle.",               Preco = 39.90m,  Categoria = "Livro" },
                new() { Nome = "O Pequeno Príncipe",                   Descricao = "Obra de Antoine de Saint-Exupéry sobre amizade e valores.",           Preco = 24.90m,  Categoria = "Livro" },
                new() { Nome = "Capitães da Areia",                    Descricao = "Romance de Jorge Amado sobre jovens em situação de rua.",             Preco = 34.90m,  Categoria = "Livro" },
                new() { Nome = "Memórias Póstumas de Brás Cubas",      Descricao = "Clássico de Machado de Assis narrado por um defunto.",               Preco = 37.50m,  Categoria = "Livro" },
                new() { Nome = "Harry Potter e a Pedra Filosofal",     Descricao = "Primeira aventura do jovem bruxo Harry Potter.",                      Preco = 49.90m,  Categoria = "Livro" },
                new() { Nome = "Senhor dos Anéis: A Sociedade do Anel",Descricao = "Início da épica jornada criada por Tolkien.",                         Preco = 59.90m,  Categoria = "Livro" },
                new() { Nome = "Código Limpo",                         Descricao = "Guia de boas práticas para desenvolvimento de software.",             Preco = 89.90m,  Categoria = "Livro" },
            };

            await context.Produtos.AddRangeAsync(produtos);
            await context.SaveChangesAsync();
        }
    }
}