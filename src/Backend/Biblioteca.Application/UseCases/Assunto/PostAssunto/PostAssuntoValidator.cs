using Biblioteca.Communication.Requests;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Assunto.PostAssunto
{
    public class PostAssuntoValidator : AbstractValidator<PostAssuntoRequest>
    {
        public PostAssuntoValidator()
        {
            Include(new AssuntoValidator());
        }
    }
}
