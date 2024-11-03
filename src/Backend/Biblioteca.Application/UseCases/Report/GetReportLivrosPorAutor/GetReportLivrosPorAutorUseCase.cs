using AutoMapper;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Repositories.Report;

namespace Biblioteca.Application.UseCases.Report.GetReportLivrosPorAutor
{
    public class GetReportLivrosPorAutorUseCase : IGetReportLivrosPorAutorUseCase
    {
        private readonly IMapper _mapper;
        private readonly IReportReadOnlyRepository _readOnlyRepository;

        public GetReportLivrosPorAutorUseCase(IMapper mapper,
                                 IReportReadOnlyRepository readOnlyRepository)
        {
            _mapper = mapper;
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetReportLivrosPorAutorResponse>> Execute()
        {
            var reportLivrosPorAutor = await _readOnlyRepository.GetReportLivrosPorAutorAsync();

            var response = _mapper.Map<IEnumerable<GetReportLivrosPorAutorResponse>>(reportLivrosPorAutor);

            return response;
        }
    }
}
