using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions options) : base(options) { }

        public required DbSet<Assunto> Assunto { get; set; }
        public required DbSet<Autor> Autor { get; set; }
        public required DbSet<Livro> Livro { get; set; }
        public required DbSet<FormaCompra> FormaCompra { get; set; }

        public required DbSet<Livro_Autor> Livro_Autor { get; set; }
        public required DbSet<Livro_Assunto> Livro_Assunto { get; set; }
        public required DbSet<Livro_FormaCompra> Livro_FormaCompra { get; set; }

        public required DbSet<LivrosPorAutorView> LivrosPorAutor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaDbContext).Assembly);
        }
    }
}
