using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Livro;
using Biblioteca.Domain.Repositories.LivroAssunto;
using Biblioteca.Domain.Repositories.LivroAutor;
using Biblioteca.Domain.Repositories.LivroFormaCompra;
using Biblioteca.Exceptions;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Livro.PutLivro
{
    public class PutLivroUseCase : IPutLivroUseCase
    {
        private readonly IMapper _mapper;
        private readonly ILivroWriteOnlyRepository _writeOnlyRepository;
        private readonly ILivroReadOnlyRepository _readOnlyRepository;
        private readonly ILivroAutorWriteOnlyRepository _livroAutorWriteOnlyRepository;
        private readonly ILivroAssuntoWriteOnlyRepository _livroAssuntoWriteOnlyRepository;
        private readonly ILivroFormaCompraWriteOnlyRepository _livroFormaCompraWriteOnlyRepository;
        private readonly ILivroUseCase _livroUseCase;

        public PutLivroUseCase(IMapper mapper,
                                 ILivroWriteOnlyRepository writeOnlyRepository,
                                 ILivroReadOnlyRepository readOnlyRepository,
                                 ILivroAutorWriteOnlyRepository livroAutorWriteOnlyRepository,
                                 ILivroAssuntoWriteOnlyRepository livroAssuntoWriteOnlyRepository,
                                 ILivroFormaCompraWriteOnlyRepository livroFormaCompraWriteOnlyRepository,
                                 ILivroUseCase livroUseCase)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _livroAutorWriteOnlyRepository = livroAutorWriteOnlyRepository;
            _livroAssuntoWriteOnlyRepository = livroAssuntoWriteOnlyRepository;
            _livroFormaCompraWriteOnlyRepository = livroFormaCompraWriteOnlyRepository;
            _livroUseCase = livroUseCase;
        }

        public async Task Execute(PutLivroRequest request)
        {
            var livro = await Validate(request);
            livro.Livro_Autores.Clear();
            livro.Livro_Assuntos.Clear();
            livro.Livro_FormaCompras.Clear();

            await _livroAutorWriteOnlyRepository.DeleteLivroAutorByCodlAsync(livro.Codl);
            await _livroAssuntoWriteOnlyRepository.DeleteLivroAssuntoByCodlAsync(livro.Codl);
            await _livroFormaCompraWriteOnlyRepository.DeleteLivroFormaCompraByCodlAsync(livro.Codl);

            livro = _mapper.Map<Domain.Entities.Livro>(request);

            livro.Livro_Autores = await _livroUseCase.AddAutores(request.AutoresIds);
            livro.Livro_Assuntos = await _livroUseCase.AddAssuntos(request.AssuntosIds);
            livro.Livro_FormaCompras = await _livroUseCase.AddFormasCompras(request.FormasCompras);

            await _writeOnlyRepository.PutLivroAsync(livro);
        }

        private async Task<Domain.Entities.Livro> Validate(PutLivroRequest request)
        {
            var validator = new PutLivroValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }

            var livroExist = await _readOnlyRepository.GetByIdWithChildrenAsync(request.Codl);

            return livroExist is null ? throw new NotFoundException([ResourceMessagesException.BOOK_NOT_FOUND]) : livroExist;
        }
    }
}
