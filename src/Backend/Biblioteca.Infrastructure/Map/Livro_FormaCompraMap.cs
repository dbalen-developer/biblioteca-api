using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class Livro_FormaCompraMap : IEntityTypeConfiguration<Livro_FormaCompra>
    {
        public void Configure(EntityTypeBuilder<Livro_FormaCompra> builder)
        {
            builder.HasKey(la => new { la.LivroCodL, la.FormaCompra_CodFo });
            builder.Property(x => x.Preco).HasColumnType("DECIMAL(18,2)").IsRequired();

            builder.HasOne(la => la.Livro)
                   .WithMany(l => l.Livro_FormaCompras)
                   .HasForeignKey(la => la.LivroCodL)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.FormaCompra)
                   .WithMany(a => a.Livro_FormaCompras)
                   .HasForeignKey(la => la.FormaCompra_CodFo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
