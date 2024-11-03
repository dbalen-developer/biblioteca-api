namespace Biblioteca.Domain.Repositories.LivroFormaCompra
{
    public interface ILivroFormaCompraWriteOnlyRepository
    {
        Task DeleteLivroFormaCompraByCodlAsync(int codl);
    }
}
