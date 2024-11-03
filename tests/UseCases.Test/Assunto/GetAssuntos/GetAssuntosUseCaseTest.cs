using Biblioteca.Application.UseCases.Assunto.GetAssuntos;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Test.Assunto.GetAssuntos
{
    public class GetAssuntosUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var assunto = AssuntoBuilder.Build();

            var assuntos = new List<Biblioteca.Domain.Entities.Assunto>() { assunto! };

            var useCase = CreateUseCase(assuntos);

            var result = await useCase.Execute();

            result.Should().NotBeNull();
            result.First().Descricao.Should().Be(assunto.Descricao);
        }

        private static GetAssuntosUseCase CreateUseCase(IEnumerable<Biblioteca.Domain.Entities.Assunto> assuntos)
        {
            var mapper = MapperBuilder.Build();
            var readRepositoryBuilder = new AssuntoReadOnlyRepositoryBuilder();
            readRepositoryBuilder.GetAssuntosAsync(assuntos);

            return new GetAssuntosUseCase(mapper, readRepositoryBuilder.Build());
        }
    }
}
