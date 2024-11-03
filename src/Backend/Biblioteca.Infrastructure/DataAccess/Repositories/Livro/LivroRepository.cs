using Biblioteca.Domain.Repositories.Livro;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.Livro
{
    public class LivroRepository : ILivroReadOnlyRepository, ILivroWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task DeleteLivroAsync(Domain.Entities.Livro request)
        {
            _dbContext.Livro.Remove(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Livro?> GetByIdWithChildrenAsync(int id)
        {
            return await _dbContext.Livro
                 .AsNoTracking()
                 .Include(l => l.Livro_Autores)
                 .ThenInclude(la => la.Autor)
                 .Include(l => l.Livro_Assuntos)
                 .ThenInclude(ls => ls.Assunto)
                 .Include(l => l.Livro_FormaCompras)
                 .ThenInclude(lf => lf.FormaCompra)
                 .FirstOrDefaultAsync(a => a.Codl == id);
        }

        public async Task<Domain.Entities.Livro?> GetByIdAsync(int id)
        {
            return await _dbContext.Livro
                .AsNoTracking().FirstOrDefaultAsync(a => a.Codl == id);
        }

        public async Task<IEnumerable<Domain.Entities.Livro>> GetLivrosAsync()
        {
            return await _dbContext.Livro
                .AsNoTracking()
                .Include(l => l.Livro_Autores)
                .ThenInclude(la => la.Autor)
                .Include(l => l.Livro_Assuntos)
                .ThenInclude(ls => ls.Assunto)
                .Include(l => l.Livro_FormaCompras)
                .ThenInclude(lf => lf.FormaCompra)
                .ToListAsync();
        }

        public async Task<int> PostLivroAsync(Domain.Entities.Livro request)
        {
            await _dbContext.Livro.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request.Codl;
        }

        public async Task PutLivroAsync(Domain.Entities.Livro request)
        {
            _dbContext.Livro.Update(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
