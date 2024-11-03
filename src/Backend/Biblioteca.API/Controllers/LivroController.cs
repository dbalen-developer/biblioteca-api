using Biblioteca.Application.UseCases.Livro.DeleteLivro;
using Biblioteca.Application.UseCases.Livro.GetLivros;
using Biblioteca.Application.UseCases.Livro.PostLivro;
using Biblioteca.Application.UseCases.Livro.PutLivro;
using Biblioteca.Communication.Requests;
using Biblioteca.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class LivroController : BaseController
    {
        [HttpGet("livros")]
        [ProducesResponseType(typeof(IEnumerable<GetLivrosResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLivros([FromServices] IGetLivrosUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpPost("livro")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLivro(
            [FromServices] IPostLivroUseCase useCase,
            [FromBody] PostLivroRequest request)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }

        [HttpDelete("livro/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLivro(
            [FromServices] IDeleteLivroUseCase useCase,
            [FromRoute] int id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut("livro")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutLivro(
            [FromServices] IPutLivroUseCase useCase,
            [FromBody] PutLivroRequest request)
        {
            await useCase.Execute(request);
            return NoContent();
        }
    }
}
