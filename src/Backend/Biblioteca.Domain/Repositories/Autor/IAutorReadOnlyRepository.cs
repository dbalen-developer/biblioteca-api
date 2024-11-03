namespace Biblioteca.Domain.Repositories.Autor
{
    public interface IAutorReadOnlyRepository
    {
        Task<IEnumerable<Entities.Autor?>> GetAutorByIdsAsync(IEnumerable<int> autoresIds);
        Task<Entities.Autor?> GetByIdAsync(int id);
        Task<IEnumerable<Entities.Autor>> GetAutoresAsync();
    }
}
