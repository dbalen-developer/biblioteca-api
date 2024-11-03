namespace Biblioteca.Domain.Repositories.Report
{
    public interface IReportReadOnlyRepository
    {
        Task<IEnumerable<Entities.LivrosPorAutorView>> GetReportLivrosPorAutorAsync();
    }
}
