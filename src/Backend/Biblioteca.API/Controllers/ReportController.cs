using Biblioteca.Application.UseCases.Report.GetReportLivrosPorAutor;
using Biblioteca.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class ReportController : BaseController
    {
        [HttpGet("report/livros-por-autor")]
        [ProducesResponseType(typeof(IEnumerable<GetReportLivrosPorAutorResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReportLivrosPorAutor([FromServices] IGetReportLivrosPorAutorUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }
    }
}
