using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Autor
{
    public class AutorValidator : AbstractValidator<AutorRequest>
    {
        public AutorValidator()
        {
            RuleFor(a => a.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ResourceMessagesException.NAME_REQUIRED)
                .Length(1, 40).WithMessage(ResourceMessagesException.NAME_RANGE);

        }
    }
}
