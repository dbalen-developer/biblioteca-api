using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Assunto;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Assunto.PostAssunto
{
    public class PostAssuntoUseCase : IPostAssuntoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAssuntoWriteOnlyRepository _writeOnlyRepository;

        public PostAssuntoUseCase(IMapper mapper,
                                 IAssuntoWriteOnlyRepository writeOnlyRepository)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public async Task<int> Execute(PostAssuntoRequest request)
        {
            Validate(request);

            var assunto = _mapper.Map<Domain.Entities.Assunto>(request);
            return await _writeOnlyRepository.PostAssuntoAsync(assunto);
        }

        private static void Validate(PostAssuntoRequest request)
        {
            var validator = new PostAssuntoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }
        }
    }
}
