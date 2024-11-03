using Biblioteca.Communication.Requests;
using Biblioteca.Exceptions;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Livro
{
    public class LivroValidator : AbstractValidator<LivroRequest>
    {
        public LivroValidator()
        {
            RuleFor(l => l.Titulo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ResourceMessagesException.TITLE_REQUIRED)
                .Length(1, 40).WithMessage(ResourceMessagesException.TITLE_RANGE);

            RuleFor(l => l.Editora)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(ResourceMessagesException.PUBLISHER_REQUIRED)
                .Length(1, 40).WithMessage(ResourceMessagesException.PUBLISHER_RANGE);

            RuleFor(l => l.Edicao)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 9999).WithMessage(ResourceMessagesException.EDITION_RANGE);

            RuleFor(l => l.AnoPublicacao)
                .Cascade(CascadeMode.Stop)
                .Matches(@"^[1-9]\d{3}$").WithMessage(ResourceMessagesException.PUBLICATION_YEAR_MATCH);

            RuleFor(l => l.AutoresIds)
                .NotEmpty().WithMessage(ResourceMessagesException.LIST_AUTHOR_REQUIRED);

            RuleFor(l => l.AssuntosIds)
                .NotEmpty().WithMessage(ResourceMessagesException.LIST_SUBJECT_REQUIRED);

            RuleForEach(l => l.FormasCompras)
                .ChildRules(child =>
                {
                    child.RuleFor(x => x.Preco).LessThan(9999999999999999).WithMessage(ResourceMessagesException.INVALID_PRICE);
                });
        }
    }
}
