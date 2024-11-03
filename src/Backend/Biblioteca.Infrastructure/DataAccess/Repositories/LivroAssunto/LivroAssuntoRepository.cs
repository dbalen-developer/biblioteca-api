using Biblioteca.Domain.Repositories.LivroAssunto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.LivroAssunto
{
    public class LivroAssuntoRepository : ILivroAssuntoWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroAssuntoRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task DeleteLivroAssuntoByCodlAsync(int codl)
        {
            var livrosAssuntosParaDeletar = await _dbContext.Livro_Assunto.Where(l => l.Livro_Codl == codl).ToListAsync();
            _dbContext.Livro_Assunto.RemoveRange(livrosAssuntosParaDeletar);
        }
    }
}
