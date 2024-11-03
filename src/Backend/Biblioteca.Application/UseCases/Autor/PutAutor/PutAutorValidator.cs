using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Autor.PutAutor
{
    public class PutAutorValidator : AbstractValidator<PutAutorRequest>
    {
        public PutAutorValidator()
        {
            RuleFor(a => a.CodAu)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(ResourceMessagesException.INVALID_ID);

            Include(new AutorValidator());
        }
    }
}
