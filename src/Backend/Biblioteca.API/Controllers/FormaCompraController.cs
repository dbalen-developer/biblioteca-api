using Biblioteca.Application.UseCases.FormaCompra.GetFormasCompras;
using Biblioteca.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class FormaCompraController : BaseController
    {
        [HttpGet("formas-de-compras")]
        [ProducesResponseType(typeof(IEnumerable<GetFormasComprasResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFormaCompras([FromServices] IGetFormasComprasUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }
    }
}
