using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Autor;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Autor.PostAutore
{
    public class PostAutorUseCase : IPostAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorWriteOnlyRepository _writeOnlyRepository;

        public PostAutorUseCase(IMapper mapper,
                                 IAutorWriteOnlyRepository writeOnlyRepository)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
        }

        public async Task<int> Execute(PostAutorRequest request)
        {
            Validate(request);

            var autor = _mapper.Map<Domain.Entities.Autor>(request);
            return await _writeOnlyRepository.PostAutorAsync(autor);
        }

        private static void Validate(PostAutorRequest request)
        {
            var validator = new PostAutorValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }
        }
    }
}
