using Api;
using Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Teste
{
    public class ConfiguracaoDeBanco: WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(Services =>
            {
                var decriptor = Services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Banco>));

                if (decriptor != null)
                {
                    Services.Remove(decriptor);
                }

                Services.AddDbContext<Banco>(options =>
                options.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;Database=teste;Trusted_Connection=True;TrustServerCertificate=True"));
            });
            
        }

        public void LimparBanco()
        {
            var scope = Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<Banco>();
            db.Database.Migrate();
            db.Usuarios.RemoveRange(db.Usuarios);
            db.SaveChanges();
        }
    }
}
