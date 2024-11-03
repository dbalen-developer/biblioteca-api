using Biblioteca.Domain.Repositories.Assunto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.Assunto
{
    public class AssuntoRepository : IAssuntoReadOnlyRepository, IAssuntoWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public AssuntoRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IEnumerable<Domain.Entities.Assunto?>> GetAssuntoByIdsAsync(IEnumerable<int> assuntosIds)
        {
            return await _dbContext.Assunto
                .AsNoTracking().Where(l => assuntosIds.Contains(l.CodAs)).ToListAsync();
        }

        public async Task<Domain.Entities.Assunto?> GetByIdAsync(int id)
        {
            return await _dbContext.Assunto
                .AsNoTracking().Include(a => a.Livro_Assuntos).FirstOrDefaultAsync(a => a.CodAs == id);
        }

        public async Task<IEnumerable<Domain.Entities.Assunto>> GetAssuntosAsync()
        {
            return await _dbContext.Assunto
                .AsNoTracking().ToListAsync();
        }

        public async Task<int> PostAssuntoAsync(Domain.Entities.Assunto request)
        {
            await _dbContext.Assunto.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return request.CodAs;
        }

        public async Task DeleteAssuntoAsync(Domain.Entities.Assunto request)
        {
            _dbContext.Assunto.Remove(request!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutAssuntoAsync(Domain.Entities.Assunto request)
        {
            _dbContext.Assunto.Update(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
