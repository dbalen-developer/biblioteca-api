using AutoMapper;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Repositories.Autor;

namespace Biblioteca.Application.UseCases.Autor.GetAutores
{
    public class GetAutoresUseCase : IGetAutoresUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorReadOnlyRepository _readOnlyRepository;

        public GetAutoresUseCase(IMapper mapper,
                                 IAutorReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetAutoresResponse>> Execute()
        {
            var autores = await _readOnlyRepository.GetAutoresAsync();

            var response = _mapper.Map<IEnumerable<GetAutoresResponse>>(autores);

            return response;
        }
    }
}
