using AutoMapper;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Repositories.Livro;

namespace Biblioteca.Application.UseCases.Livro.GetLivros
{
    public class GetLivrosUseCase : IGetLivrosUseCase
    {
        private readonly IMapper _mapper;
        private readonly ILivroReadOnlyRepository _readOnlyRepository;

        public GetLivrosUseCase(IMapper mapper,
                                 ILivroReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetLivrosResponse>> Execute()
        {
            var autores = await _readOnlyRepository.GetLivrosAsync();

            var response = _mapper.Map<IEnumerable<GetLivrosResponse>>(autores);

            return response;
        }
    }
}
