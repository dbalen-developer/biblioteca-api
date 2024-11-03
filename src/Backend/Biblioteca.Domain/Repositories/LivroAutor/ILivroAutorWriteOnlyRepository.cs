namespace Biblioteca.Domain.Repositories.LivroAutor
{
    public interface ILivroAutorWriteOnlyRepository
    {
        Task DeleteLivroAutorByCodlAsync(int codl);
    }
}
