using Biblioteca.Application.UseCases.Assunto.DeleteAssunto;
using Biblioteca.Application.UseCases.Assunto.GetAssuntos;
using Biblioteca.Application.UseCases.Assunto.PostAssunto;
using Biblioteca.Application.UseCases.Assunto.PutAssunto;
using Biblioteca.Communication.Requests;
using Biblioteca.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class AssuntoController : BaseController
    {
        [HttpGet("assuntos")]
        [ProducesResponseType(typeof(IEnumerable<GetAssuntosResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssuntos([FromServices] IGetAssuntosUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpPost("assunto")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAssunto(
            [FromServices] IPostAssuntoUseCase useCase,
            [FromBody] PostAssuntoRequest request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpDelete("assunto/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAssunto(
            [FromServices] IDeleteAssuntoUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPut("assunto")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAssunto(
            [FromServices] IPutAssuntoUseCase useCase,
            [FromBody] PutAssuntoRequest request)
        {
            await useCase.Execute(request);
            return NoContent();
        }
    }
}
