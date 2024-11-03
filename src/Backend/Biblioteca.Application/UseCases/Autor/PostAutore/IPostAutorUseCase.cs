using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Autor.PostAutore
{
    public interface IPostAutorUseCase
    {
        Task<int> Execute(PostAutorRequest request);
    }
}
