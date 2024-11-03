namespace Biblioteca.Domain.Repositories.Livro
{
    public interface ILivroWriteOnlyRepository
    {
        Task<int> PostLivroAsync(Entities.Livro request);
        Task DeleteLivroAsync(Entities.Livro request);
        Task PutLivroAsync(Entities.Livro request);
    }
}
