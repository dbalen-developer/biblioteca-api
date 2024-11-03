using Biblioteca.Communication.Requests;

namespace Biblioteca.Application.UseCases.Autor.PutAutor
{
    public interface IPutAutorUseCase
    {
        Task Execute(PutAutorRequest request);
    }
}
