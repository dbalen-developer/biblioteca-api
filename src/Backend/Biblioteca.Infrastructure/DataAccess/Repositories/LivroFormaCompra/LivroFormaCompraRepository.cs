using Biblioteca.Domain.Repositories.LivroFormaCompra;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.LivroFormaCompra
{
    public class LivroFormaCompraRepository : ILivroFormaCompraWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroFormaCompraRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task DeleteLivroFormaCompraByCodlAsync(int codl)
        {
            var livrosFormaCompraParaDeletar = await _dbContext.Livro_FormaCompra.Where(l => l.LivroCodL == codl).ToListAsync();
            _dbContext.Livro_FormaCompra.RemoveRange(livrosFormaCompraParaDeletar);
        }
    }
}
