using Biblioteca.Communication.Responses;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Biblioteca.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomBaseException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is CustomValidationException exception)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(new ErrorResponse(exception.ErrorMessages));
            }
            else if (context.Exception is NotFoundException notFoundException)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new NotFoundObjectResult(new ErrorResponse(notFoundException.ErrorMessages));
            }

            //Podemos ter outras exceptions aqui por exemplo invalid login (401)
            //else if (context.Exception is InvalidLoginException)
            //{
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(context.Exception.Message));
            //}
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorResponse(ResourceMessagesException.UNKNOWN_ERROR));
        }
    }
}
