using Biblioteca.Domain.Repositories.FormaCompra;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.FormaCompra
{
    public class FormaCompraRepository : IFormaCompraReadOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public FormaCompraRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IEnumerable<Domain.Entities.FormaCompra?>> GetFormaComprasByIdsAsync(IEnumerable<int> formaComprasIds)
        {
            return await _dbContext.FormaCompra
                .AsNoTracking().Where(l => formaComprasIds.Contains(l.CodFo)).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.FormaCompra>> GetFormaComprasAsync()
        {
            return await _dbContext.FormaCompra
                .AsNoTracking().ToListAsync();
        }
    }
}
