namespace Biblioteca.Application.UseCases.Livro.DeleteLivro
{
    public interface IDeleteLivroUseCase
    {
        Task Execute(int id);
    }
}
