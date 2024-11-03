namespace Biblioteca.Domain.Repositories.Autor
{
    public interface IAutorWriteOnlyRepository
    {
        Task<int> PostAutorAsync(Entities.Autor request);
        Task DeleteAutorAsync(Entities.Autor request);
        Task PutAutorAsync(Entities.Autor request);
    }
}
