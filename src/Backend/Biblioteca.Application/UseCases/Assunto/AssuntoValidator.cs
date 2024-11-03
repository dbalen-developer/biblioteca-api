using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Assunto
{
    public class AssuntoValidator : AbstractValidator<AssuntoRequest>
    {
        public AssuntoValidator()
        {
            RuleFor(a => a.Descricao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ResourceMessagesException.DESCRIPTION_REQUIRED)
                .Length(1, 20).WithMessage(ResourceMessagesException.DESCRIPTION_RANGE);
        }
    }
}
