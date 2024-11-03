using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Autor;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Autor.PutAutor
{
    public class PutAutorUseCase : IPutAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorWriteOnlyRepository _writeOnlyRepository;
        private readonly IAutorReadOnlyRepository _readOnlyRepository;

        public PutAutorUseCase(IMapper mapper,
                                 IAutorWriteOnlyRepository writeOnlyRepository,
                                 IAutorReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task Execute(PutAutorRequest request)
        {
            await Validate(request);

            var autor = _mapper.Map<Domain.Entities.Autor>(request);
            await _writeOnlyRepository.PutAutorAsync(autor);
        }

        private async Task Validate(PutAutorRequest request)
        {
            var validator = new PutAutorValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }

            var autorExist = await _readOnlyRepository.GetByIdAsync(request.CodAu);

            if (autorExist is null)
                throw new NotFoundException([ResourceMessagesException.AUTHOR_NOT_FOUND]);
        }
    }
}
