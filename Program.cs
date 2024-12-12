using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurante;
using Restaurante.Service;
using Restaurante.Service.Sedding;

namespace Restaurante
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ReservasContext>(options =>

            options.UseMySql(

            builder.Configuration.GetConnectionString("ReservasContext")

            ?? throw new InvalidOperationException("Connection string 'ReservasContext' not found."),

            new MySqlServerVersion(new Version(8, 0, 32))

            ));





            builder.Services.AddScoped<ReservaService>();

            builder.Services.AddScoped<SeedingService>();



            builder.Services.AddControllersWithViews();



            var app = builder.Build();





            if (app.Environment.IsDevelopment())

            {

                using (var scope = app.Services.CreateScope())

                {

                    var services = scope.ServiceProvider;



                    try

                    {

                        var seedingService = services.GetRequiredService<SeedingService>();

                        await seedingService.Seed();

                        Console.WriteLine("Seeding concluído com sucesso.");

                    }

                    catch (Exception ex)

                    {

                        Console.WriteLine($"Erro ao executar o seeding: {ex.Message}");

                    }

                }

            }

            if (!app.Environment.IsDevelopment())

            {

                app.UseExceptionHandler("/Home/Error");



                app.UseHsts();

            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();



            app.UseRouting();



            app.UseAuthorization();



            app.MapControllerRoute(

                name: "default",

                pattern: "{controller=Home}/{action=Index}/{id?}"
            );



            app.Run();

        }
    }
}