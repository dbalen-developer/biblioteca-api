namespace Biblioteca.Domain.Repositories.FormaCompra
{
    public interface IFormaCompraReadOnlyRepository
    {
        Task<IEnumerable<Entities.FormaCompra?>> GetFormaComprasByIdsAsync(IEnumerable<int> formaComprasIds);
        Task<IEnumerable<Entities.FormaCompra>> GetFormaComprasAsync();
    }
}
