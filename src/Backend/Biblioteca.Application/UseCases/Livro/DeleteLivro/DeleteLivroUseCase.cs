using Biblioteca.Domain.Repositories.Livro;
using Biblioteca.Domain.Repositories.LivroAssunto;
using Biblioteca.Domain.Repositories.LivroAutor;
using Biblioteca.Domain.Repositories.LivroFormaCompra;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Livro.DeleteLivro
{
    public class DeleteLivroUseCase : IDeleteLivroUseCase
    {
        private readonly ILivroWriteOnlyRepository _writeOnlyRepository;
        private readonly ILivroAutorWriteOnlyRepository _livroAutorWriteOnlyRepository;
        private readonly ILivroAssuntoWriteOnlyRepository _livroAssuntoWriteOnlyRepository;
        private readonly ILivroFormaCompraWriteOnlyRepository _livroFormaCompraWriteOnlyRepository;
        private readonly ILivroReadOnlyRepository _readOnlyRepository;

        public DeleteLivroUseCase(
            ILivroReadOnlyRepository readOnlyRepository,
            ILivroAutorWriteOnlyRepository livroAutorWriteOnlyRepository,
            ILivroAssuntoWriteOnlyRepository livroAssuntoWriteOnlyRepository,
            ILivroFormaCompraWriteOnlyRepository livroFormaCompraWriteOnlyRepository,
            ILivroWriteOnlyRepository writeOnlyRepository)
        {
            _livroAutorWriteOnlyRepository = livroAutorWriteOnlyRepository;
            _livroAssuntoWriteOnlyRepository = livroAssuntoWriteOnlyRepository;
            _livroFormaCompraWriteOnlyRepository = livroFormaCompraWriteOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task Execute(int id)
        {
            var livro = await Validate(id);

            await _livroAutorWriteOnlyRepository.DeleteLivroAutorByCodlAsync(id);
            await _livroAssuntoWriteOnlyRepository.DeleteLivroAssuntoByCodlAsync(id);
            await _livroFormaCompraWriteOnlyRepository.DeleteLivroFormaCompraByCodlAsync(id);
            await _writeOnlyRepository.DeleteLivroAsync(livro);
        }

        private async Task<Domain.Entities.Livro> Validate(int id)
        {
            var livroExist = await _readOnlyRepository.GetByIdAsync(id);

            return livroExist is null ? throw new NotFoundException([ResourceMessagesException.BOOK_NOT_FOUND]) : livroExist;
        }
    }
}
