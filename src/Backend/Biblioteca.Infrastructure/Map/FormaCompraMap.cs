using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class FormaCompraMap : IEntityTypeConfiguration<FormaCompra>
    {
        public void Configure(EntityTypeBuilder<FormaCompra> builder)
        {
            builder.HasKey(a => a.CodFo);
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(30)").IsRequired();

            builder.HasData(
                new FormaCompra { CodFo = 1, Descricao = "Balcão" },
                new FormaCompra { CodFo = 2, Descricao = "Self-Service" },
                new FormaCompra { CodFo = 3, Descricao = "Internet" },
                new FormaCompra { CodFo = 4, Descricao = "Evento" });
        }
    }
}
