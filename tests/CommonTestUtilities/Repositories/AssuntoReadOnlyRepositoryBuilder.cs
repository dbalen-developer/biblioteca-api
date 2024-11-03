using Biblioteca.Domain.Repositories.Assunto;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class AssuntoReadOnlyRepositoryBuilder
    {
        private readonly Mock<IAssuntoReadOnlyRepository> _repository;

        public AssuntoReadOnlyRepositoryBuilder() => _repository = new Mock<IAssuntoReadOnlyRepository>();

        public void GetAssuntosAsync(IEnumerable<Biblioteca.Domain.Entities.Assunto> assuntos)
        {
            _repository.Setup(repository => repository.GetAssuntosAsync()).ReturnsAsync(assuntos);
        }

        public IAssuntoReadOnlyRepository Build()
        {
            return _repository.Object;
        }
    }
}
