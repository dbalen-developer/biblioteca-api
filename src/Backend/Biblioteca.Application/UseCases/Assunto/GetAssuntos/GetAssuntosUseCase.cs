using AutoMapper;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Repositories.Assunto;

namespace Biblioteca.Application.UseCases.Assunto.GetAssuntos
{
    public class GetAssuntosUseCase : IGetAssuntosUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAssuntoReadOnlyRepository _readOnlyRepository;

        public GetAssuntosUseCase(IMapper mapper,
                                 IAssuntoReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetAssuntosResponse>> Execute()
        {
            var autores = await _readOnlyRepository.GetAssuntosAsync();

            var response = _mapper.Map<IEnumerable<GetAssuntosResponse>>(autores);

            return response;
        }
    }
}
