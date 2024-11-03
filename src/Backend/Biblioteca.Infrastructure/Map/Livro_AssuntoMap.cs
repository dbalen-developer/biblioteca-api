using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class Livro_AssuntoMap : IEntityTypeConfiguration<Livro_Assunto>
    {
        public void Configure(EntityTypeBuilder<Livro_Assunto> builder)
        {
            builder.HasKey(la => new { la.Livro_Codl, la.Assunto_CodAs });

            builder.HasOne(la => la.Livro)
                   .WithMany(l => l.Livro_Assuntos)
                   .HasForeignKey(la => la.Livro_Codl)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.Assunto)
                   .WithMany(a => a.Livro_Assuntos)
                   .HasForeignKey(la => la.Assunto_CodAs)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
