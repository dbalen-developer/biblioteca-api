using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Livro.PutLivro
{
    public interface IPutLivroUseCase
    {
        Task Execute(PutLivroRequest request);
    }
}
