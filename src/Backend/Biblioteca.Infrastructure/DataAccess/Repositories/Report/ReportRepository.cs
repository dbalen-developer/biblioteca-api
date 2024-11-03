using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories.Report;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.Report
{
    public class ReportRepository : IReportReadOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public ReportRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IEnumerable<LivrosPorAutorView>> GetReportLivrosPorAutorAsync()
        {
            return await _dbContext.LivrosPorAutor
                .AsNoTracking().ToListAsync();
        }
    }
}
