using Biblioteca.Domain.Repositories.Assunto;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Assunto.DeleteAssunto
{
    public class DeleteAssuntoUseCase : IDeleteAssuntoUseCase
    {
        private readonly IAssuntoWriteOnlyRepository _writeOnlyRepository;
        private readonly IAssuntoReadOnlyRepository _readOnlyRepository;

        public DeleteAssuntoUseCase(IAssuntoWriteOnlyRepository writeOnlyRepository,
                                 IAssuntoReadOnlyRepository readOnlyRepository)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task Execute(int id)
        {
            var Assunto = await Validate(id);
            await _writeOnlyRepository.DeleteAssuntoAsync(Assunto);
        }

        private async Task<Domain.Entities.Assunto> Validate(int id)
        {
            var assuntoExist = await _readOnlyRepository.GetByIdAsync(id);

            if (assuntoExist is null)
                throw new NotFoundException([ResourceMessagesException.SUBJECT_NOT_FOUND]);
            else if (assuntoExist.Livro_Assuntos.Count != 0)
                throw new CustomValidationException([ResourceMessagesException.SUBJECT_WITH_REFERENCE]);

            return assuntoExist;
        }
    }
}
