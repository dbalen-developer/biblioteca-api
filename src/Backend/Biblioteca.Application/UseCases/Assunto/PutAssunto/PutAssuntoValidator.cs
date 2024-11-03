using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Assunto.PutAssunto
{
    public class PutAssuntoValidator : AbstractValidator<PutAssuntoRequest>
    {
        public PutAssuntoValidator()
        {
            RuleFor(a => a.CodAs)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(ResourceMessagesException.INVALID_ID);

            Include(new AssuntoValidator());
        }
    }
}
