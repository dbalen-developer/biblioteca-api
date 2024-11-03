using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Repositories.Livro;
using Biblioteca.Exceptions.ExceptionsBase;

namespace Biblioteca.Application.UseCases.Livro.PostLivro
{
    public class PostLivroUseCase : IPostLivroUseCase
    {
        private readonly IMapper _mapper;
        private readonly ILivroWriteOnlyRepository _writeOnlyRepository;
        private readonly ILivroUseCase _livroUseCase;

        public PostLivroUseCase(IMapper mapper,
                                 ILivroWriteOnlyRepository writeOnlyRepository,
                                 ILivroUseCase livroUseCase)
        {
            _mapper = mapper;
            _writeOnlyRepository = writeOnlyRepository;
            _livroUseCase = livroUseCase;
        }

        public async Task<int> Execute(PostLivroRequest request)
        {
            Validate(request);

            var livro = _mapper.Map<Domain.Entities.Livro>(request);
            livro.Livro_Autores = await _livroUseCase.AddAutores(request.AutoresIds);
            livro.Livro_Assuntos = await _livroUseCase.AddAssuntos(request.AssuntosIds);
            livro.Livro_FormaCompras = await _livroUseCase.AddFormasCompras(request.FormasCompras);

            return await _writeOnlyRepository.PostLivroAsync(livro);
        }

        private static void Validate(PostLivroRequest request)
        {
            var validator = new PostLivroValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessages);
            }
        }
    }
}
