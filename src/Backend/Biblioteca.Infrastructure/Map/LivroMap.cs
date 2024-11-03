using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Codl);
            builder.Property(x => x.Titulo).HasColumnType("VARCHAR(40)").IsRequired();
            builder.Property(x => x.Editora).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(x => x.Edicao).IsRequired();
            builder.Property(x => x.AnoPublicacao).HasColumnType("VARCHAR(4)").IsRequired();
        }
    }
}
