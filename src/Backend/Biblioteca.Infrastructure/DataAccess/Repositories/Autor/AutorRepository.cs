using Biblioteca.Domain.Repositories.Autor;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.Autor
{
    public class AutorRepository : IAutorReadOnlyRepository, IAutorWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public AutorRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IEnumerable<Domain.Entities.Autor?>> GetAutorByIdsAsync(IEnumerable<int> autoresIds)
        {
            return await _dbContext.Autor
                .AsNoTracking().Where(l => autoresIds.Contains(l.CodAu)).ToListAsync();
        }

        public async Task<Domain.Entities.Autor?> GetByIdAsync(int id)
        {
            return await _dbContext.Autor
                .AsNoTracking().Include(a => a.Livro_Autores).FirstOrDefaultAsync(a => a.CodAu == id);
        }

        public async Task<IEnumerable<Domain.Entities.Autor>> GetAutoresAsync()
        {
            return await _dbContext.Autor
                .AsNoTracking().ToListAsync();
        }

        public async Task<int> PostAutorAsync(Domain.Entities.Autor request)
        {
            await _dbContext.Autor.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request.CodAu;
        }

        public async Task DeleteAutorAsync(Domain.Entities.Autor request)
        {
            _dbContext.Autor.Remove(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutAutorAsync(Domain.Entities.Autor request)
        {
            _dbContext.Autor.Update(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
