using Biblioteca.Application.UseCases.Autor;
using Biblioteca.Exceptions;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Autor
{
    public class AutorValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new AutorValidator();

            var request = RequestAutorValidatorJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(41)]
        [InlineData(42)]
        public void Error_Name_Invalid(int assuntoLength)
        {
            var validator = new AutorValidator();

            var request = RequestAutorValidatorJsonBuilder.Build(assuntoLength);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();

            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.NAME_RANGE));
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var validator = new AutorValidator();

            var request = RequestAutorValidatorJsonBuilder.Build();
            request.Nome = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();

            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.NAME_REQUIRED));
        }
    }
}
