using Biblioteca.Communication.Responses;

namespace Biblioteca.Application.UseCases.FormaCompra.GetFormasCompras
{
    public interface IGetFormasComprasUseCase
    {
        Task<IEnumerable<GetFormasComprasResponse>> Execute();
    }
}
