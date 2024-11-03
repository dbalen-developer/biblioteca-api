using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Livro.PutLivro
{
    public class PutLivroValidator : AbstractValidator<PutLivroRequest>
    {
        public PutLivroValidator()
        {
            RuleFor(a => a.Codl)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(ResourceMessagesException.INVALID_ID);

            Include(new LivroValidator());
        }
    }
}
