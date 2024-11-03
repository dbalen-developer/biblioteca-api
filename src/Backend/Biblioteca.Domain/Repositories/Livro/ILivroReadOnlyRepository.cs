namespace Biblioteca.Domain.Repositories.Livro
{
    public interface ILivroReadOnlyRepository
    {
        Task<Domain.Entities.Livro?> GetByIdWithChildrenAsync(int id);
        Task<Entities.Livro?> GetByIdAsync(int id);
        Task<IEnumerable<Entities.Livro>> GetLivrosAsync();
    }
}
