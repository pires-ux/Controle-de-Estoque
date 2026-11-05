using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
