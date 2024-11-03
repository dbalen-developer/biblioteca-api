using Biblioteca.Domain.Repositories.Autor;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Autor.DeleteAutor
{
    public class DeleteAutorUseCase : IDeleteAutorUseCase
    {
        private readonly IAutorWriteOnlyRepository _writeOnlyRepository;
        private readonly IAutorReadOnlyRepository _readOnlyRepository;

        public DeleteAutorUseCase(IAutorWriteOnlyRepository writeOnlyRepository,
                                 IAutorReadOnlyRepository readOnlyRepository)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task Execute(int id)
        {
            var autor = await Validate(id);
            await _writeOnlyRepository.DeleteAutorAsync(autor);
        }

        private async Task<Domain.Entities.Autor> Validate(int id)
        {
            var autorExist = await _readOnlyRepository.GetByIdAsync(id);

            if (autorExist is null)
                throw new NotFoundException([ResourceMessagesException.AUTHOR_NOT_FOUND]);
            else if (autorExist.Livro_Autores.Count != 0)
                throw new CustomValidationException([ResourceMessagesException.AUTHOR_WITH_REFERENCE]);

            return autorExist;
        }
    }
}
