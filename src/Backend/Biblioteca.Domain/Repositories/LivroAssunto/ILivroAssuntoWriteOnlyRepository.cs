namespace Biblioteca.Domain.Repositories.LivroAssunto
{
    public interface ILivroAssuntoWriteOnlyRepository
    {
        Task DeleteLivroAssuntoByCodlAsync(int codl);
    }
}
