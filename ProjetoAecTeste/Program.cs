using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjetoAecTeste.Data;
using ProjetoAecTeste.Repositorios.Interfaces;
using ProjetoAecTeste.Services;
using ProjetoAecTeste.Services.Interfaces;

namespace ProjetoAecTeste
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar serviços (Dependency Injection


            builder.Services.AddDbContext<AluraSearchDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Database");
                options.UseSqlServer(connectionString);
            });


            var connectionString = builder.Configuration.GetConnectionString("Database");
            Console.WriteLine($"Connection String: {connectionString}");



            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<CursoAplication>();
           

            // Injeção do IWebDriver (Selenium ChromeDriver)
            builder.Services.AddScoped<IWebDriver>(provider =>
            {
                var chromeOptions = new ChromeOptions();
                // chromeOptions.AddArgument("--headless"); // Caso não queira abrir o browser
                return new ChromeDriver(chromeOptions);
            });

            // Adicionar serviços de controladores
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configurar middleware da aplicação
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Mapear rotas de controladores
            app.MapControllers();

            // Chamar o método BuscarCursos apenas uma vez
            await ExecuteAutomacaoAsync(app);

            // Iniciar a aplicação
            await app.RunAsync();
            
        }
      
        private static async Task ExecuteAutomacaoAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var cursoAplication = scope.ServiceProvider.GetRequiredService<CursoAplication>();
                await cursoAplication.BuscarCursos();
            }
        }
    }
}
