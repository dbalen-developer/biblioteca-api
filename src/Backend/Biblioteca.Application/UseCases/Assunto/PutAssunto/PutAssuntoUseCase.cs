using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Assunto;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Assunto.PutAssunto
{
    public class PutAssuntoUseCase : IPutAssuntoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAssuntoWriteOnlyRepository _writeOnlyRepository;
        private readonly IAssuntoReadOnlyRepository _readOnlyRepository;

        public PutAssuntoUseCase(IMapper mapper,
                                 IAssuntoWriteOnlyRepository writeOnlyRepository,
                                 IAssuntoReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task Execute(PutAssuntoRequest request)
        {
            await Validate(request);

            var assunto = _mapper.Map<Domain.Entities.Assunto>(request);
            await _writeOnlyRepository.PutAssuntoAsync(assunto);
        }

        private async Task Validate(PutAssuntoRequest request)
        {
            var validator = new PutAssuntoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }

            var assuntoExist = await _readOnlyRepository.GetByIdAsync(request.CodAs);

            if (assuntoExist is null)
                throw new NotFoundException([ResourceMessagesException.SUBJECT_NOT_FOUND]);
        }
    }
}
