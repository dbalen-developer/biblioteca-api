using AutoMapper;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Repositories.FormaCompra;

namespace Biblioteca.Application.UseCases.FormaCompra.GetFormasCompras
{
    public class GetFormasComprasUseCase : IGetFormasComprasUseCase
    {
        private readonly IMapper _mapper;
        private readonly IFormaCompraReadOnlyRepository _readOnlyRepository;

        public GetFormasComprasUseCase(IMapper mapper,
                                 IFormaCompraReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetFormasComprasResponse>> Execute()
        {
            var formaCompras = await _readOnlyRepository.GetFormaComprasAsync();

            var response = _mapper.Map<IEnumerable<GetFormasComprasResponse>>(formaCompras);

            return response;
        }
    }
}
