using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Assunto.PutAssunto
{
    public interface IPutAssuntoUseCase
    {
        Task Execute(PutAssuntoRequest request);
    }
}
