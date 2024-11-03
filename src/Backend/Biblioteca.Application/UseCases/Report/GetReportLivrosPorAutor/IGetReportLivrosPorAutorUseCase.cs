using Biblioteca.Communication.Responses;

namespace Biblioteca.Application.UseCases.Report.GetReportLivrosPorAutor
{
    public interface IGetReportLivrosPorAutorUseCase
    {
        Task<IEnumerable<GetReportLivrosPorAutorResponse>> Execute();
    }
}
