using Biblioteca.Application.UseCases.Autor.GetAutores;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Test.Autor.GetAutores
{
    public class GetAutoresUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var autor = AutorBuilder.Build();

            var autores = new List<Biblioteca.Domain.Entities.Autor>() { autor! };

            var useCase = CreateUseCase(autores);

            var result = await useCase.Execute();

            result.Should().NotBeNull();
            result.First().Nome.Should().Be(autor.Nome);
        }

        private static GetAutoresUseCase CreateUseCase(IEnumerable<Biblioteca.Domain.Entities.Autor> autores)
        {
            var mapper = MapperBuilder.Build();
            var readRepositoryBuilder = new AutorReadOnlyRepositoryBuilder();
            readRepositoryBuilder.GetAutorsAsync(autores);

            return new GetAutoresUseCase(mapper, readRepositoryBuilder.Build());
        }
    }
}
