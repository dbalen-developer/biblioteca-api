using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Assunto.PostAssunto
{
    public interface IPostAssuntoUseCase
    {
        Task<int> Execute(PostAssuntoRequest request);
    }
}
