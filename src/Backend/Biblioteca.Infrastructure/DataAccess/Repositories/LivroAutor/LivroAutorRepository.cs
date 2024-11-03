using Biblioteca.Domain.Repositories.LivroAutor;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.DataAccess.Repositories.LivroAutor
{
    public class LivroAutorRepository : ILivroAutorWriteOnlyRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroAutorRepository(BibliotecaDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task DeleteLivroAutorByCodlAsync(int codl)
        {
            var livrosAutoresParaDeletar = await _dbContext.Livro_Autor.Where(l => l.Livro_Codl == codl).ToListAsync();
            _dbContext.Livro_Autor.RemoveRange(livrosAutoresParaDeletar);
        }
    }
}
