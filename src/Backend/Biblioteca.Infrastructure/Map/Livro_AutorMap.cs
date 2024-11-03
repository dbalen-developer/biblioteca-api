using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class Livro_AutorMap : IEntityTypeConfiguration<Livro_Autor>
    {
        public void Configure(EntityTypeBuilder<Livro_Autor> builder)
        {
            builder.HasKey(la => new { la.Livro_Codl, la.Autor_CodAu });

            builder.HasOne(la => la.Livro)
                   .WithMany(l => l.Livro_Autores)
                   .HasForeignKey(la => la.Livro_Codl)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.Autor)
                   .WithMany(a => a.Livro_Autores)
                   .HasForeignKey(la => la.Autor_CodAu)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
