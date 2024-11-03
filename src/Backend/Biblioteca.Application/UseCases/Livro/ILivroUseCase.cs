using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.UseCases.Livro
{
    public interface ILivroUseCase
    {
        Task<ICollection<Livro_Autor>> AddAutores(IEnumerable<int> autoresIds);
        Task<ICollection<Livro_Assunto>> AddAssuntos(IEnumerable<int> assuntosIds);
        Task<ICollection<Livro_FormaCompra>> AddFormasCompras(IEnumerable<FormasComprasRequest> formasCompras);
    }
}
