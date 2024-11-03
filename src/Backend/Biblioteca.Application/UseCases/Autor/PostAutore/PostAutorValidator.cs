using Biblioteca.Communication.Requests;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Autor.PostAutore
{
    public class PostAutorValidator : AbstractValidator<PostAutorRequest>
    {
        public PostAutorValidator()
        {
            Include(new AutorValidator());
        }
    }
}
