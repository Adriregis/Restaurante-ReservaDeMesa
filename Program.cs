using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurante;
using Restaurante.Service;
using Restaurante.Service.Sedding;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para MySQL
builder.Services.AddDbContext<ReservasContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ReservasContext")
            ?? throw new InvalidOperationException("Connection string 'ReservasContext' not found."),
        new MySqlServerVersion(new Version(8, 0, 32)) // Altere para a versão correta do MySQL instalado
    ));

// Registrar os serviços necessários
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<SeedingService>();

// Configurar MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Executar o SeedingService no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var seedingService = services.GetRequiredService<SeedingService>();
            await seedingService.Seed(); // Aguarde o método Seed
            Console.WriteLine("Seeding concluído com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar o seeding: {ex.Message}");
        }
    }
}

// Configurar o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão de HSTS é 30 dias. Você pode alterar para produção, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
