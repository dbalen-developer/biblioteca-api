using Biblioteca.Application.UseCases.Assunto;
using Biblioteca.Exceptions;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Assunto
{
    public class AssuntoValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new AssuntoValidator();

            var request = RequestAssuntoValidatorJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(21)]
        [InlineData(22)]
        public void Error_Description_Invalid(int assuntoLength)
        {
            var validator = new AssuntoValidator();

            var request = RequestAssuntoValidatorJsonBuilder.Build(assuntoLength);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();

            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.DESCRIPTION_RANGE));
        }

        [Fact]
        public void Error_Description_Empty()
        {
            var validator = new AssuntoValidator();

            var request = RequestAssuntoValidatorJsonBuilder.Build();
            request.Descricao = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();

            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.DESCRIPTION_REQUIRED));
        }
    }
}
