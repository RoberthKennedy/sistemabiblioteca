using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sistemabiblioteca.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers + Views (MVC)
builder.Services.AddControllersWithViews();

// Banco de dados SQLite com Entity Framework Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=biblioteca.db"));

// Identity (autenticação de usuários)
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Requisitos de senha (ajuste conforme necessário)
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Redireciona para /Account/Login quando não autenticado
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});

var app = builder.Build();

// Configuração para ambiente de produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // <-- obrigatório antes de UseAuthorization
app.UseAuthorization();

// Rota padrão MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

// Executa o seed do banco de dados na inicialização
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedAsync(scope.ServiceProvider);
}

app.Run();