using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Livro.PostLivro
{
    public interface IPostLivroUseCase
    {
        Task<int> Execute(PostLivroRequest request);
    }
}
