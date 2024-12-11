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

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 dias. Você pode alterar para produção, veja https://aka.ms/aspnetcore-hsts.
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

builder.Services.AddScoped<ReservaService>();

builder.Services.AddScoped<SeedingService>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Criamos um escopo de execução nos serviços, usamos o GetRequiredService para selecionar o serviço a ser executado e selecionamos o método Seed().
    app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
}