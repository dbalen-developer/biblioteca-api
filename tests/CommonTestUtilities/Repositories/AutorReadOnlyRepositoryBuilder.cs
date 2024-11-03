using Biblioteca.Domain.Repositories.Autor;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class AutorReadOnlyRepositoryBuilder
    {
        private readonly Mock<IAutorReadOnlyRepository> _repository;

        public AutorReadOnlyRepositoryBuilder() => _repository = new Mock<IAutorReadOnlyRepository>();

        public void GetAutorsAsync(IEnumerable<Biblioteca.Domain.Entities.Autor> Autors)
        {
            _repository.Setup(repository => repository.GetAutoresAsync()).ReturnsAsync(Autors);
        }

        public IAutorReadOnlyRepository Build()
        {
            return _repository.Object;
        }
    }
}
