using Biblioteca.Communication.Requests;
using FluentValidation;
namespace Biblioteca.Application.UseCases.Livro.PostLivro
{
    public class PostLivroValidator : AbstractValidator<PostLivroRequest>
    {
        public PostLivroValidator()
        {
            Include(new LivroValidator());
        }
    }
}
