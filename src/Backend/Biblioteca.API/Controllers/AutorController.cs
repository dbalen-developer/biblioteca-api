using Biblioteca.Application.UseCases.Autor.DeleteAutor;
using Biblioteca.Application.UseCases.Autor.GetAutores;
using Biblioteca.Application.UseCases.Autor.PostAutore;
using Biblioteca.Application.UseCases.Autor.PutAutor;
using Biblioteca.Communication.Requests;
using Biblioteca.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class AutorController : BaseController
    {
        [HttpGet("autores")]
        [ProducesResponseType(typeof(IEnumerable<GetAutoresResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAutores([FromServices] IGetAutoresUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpPost("autor")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAutor(
            [FromServices] IPostAutorUseCase useCase,
            [FromBody] PostAutorRequest request)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }

        [HttpDelete("autor/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAutor(
            [FromServices] IDeleteAutorUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut("autor")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAutor(
            [FromServices] IPutAutorUseCase useCase,
            [FromBody] PutAutorRequest request)
        {
            await useCase.Execute(request);
            return NoContent();
        }
    }
}
