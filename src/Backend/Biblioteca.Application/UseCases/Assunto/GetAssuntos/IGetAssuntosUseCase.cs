using Biblioteca.Communication.Responses;

namespace Biblioteca.Application.UseCases.Assunto.GetAssuntos
{
    public interface IGetAssuntosUseCase
    {
        Task<IEnumerable<GetAssuntosResponse>> Execute();
    }
}
