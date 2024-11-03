namespace Biblioteca.Domain.Repositories.Assunto
{
    public interface IAssuntoReadOnlyRepository
    {
        Task<IEnumerable<Entities.Assunto?>> GetAssuntoByIdsAsync(IEnumerable<int> assuntosIds);
        Task<Entities.Assunto?> GetByIdAsync(int id);
        Task<IEnumerable<Entities.Assunto>> GetAssuntosAsync();
    }
}
