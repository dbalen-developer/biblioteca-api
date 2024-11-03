using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Map
{
    public class LivrosPorAutorViewMap : IEntityTypeConfiguration<LivrosPorAutorView>
    {
        public void Configure(EntityTypeBuilder<LivrosPorAutorView> builder)
        {
            builder.ToView("LivrosPorAutorView").HasNoKey();
        }
    }
}
