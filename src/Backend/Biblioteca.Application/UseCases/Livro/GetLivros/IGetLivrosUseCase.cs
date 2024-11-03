using Biblioteca.Communication.Responses;

namespace Biblioteca.Application.UseCases.Livro.GetLivros
{
    public interface IGetLivrosUseCase
    {
        Task<IEnumerable<GetLivrosResponse>> Execute();
    }
}
