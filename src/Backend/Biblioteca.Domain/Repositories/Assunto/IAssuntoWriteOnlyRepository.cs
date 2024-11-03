namespace Biblioteca.Domain.Repositories.Assunto
{
    public interface IAssuntoWriteOnlyRepository
    {
        Task<int> PostAssuntoAsync(Entities.Assunto request);
        Task DeleteAssuntoAsync(Entities.Assunto request);
        Task PutAssuntoAsync(Entities.Assunto request);
    }
}
