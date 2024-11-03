using Biblioteca.Communication.Responses;

namespace Biblioteca.Application.UseCases.Autor.GetAutores
{
    public interface IGetAutoresUseCase
    {
        Task<IEnumerable<GetAutoresResponse>> Execute();
    }
}
