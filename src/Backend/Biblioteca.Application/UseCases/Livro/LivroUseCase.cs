using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories.Assunto;
using Biblioteca.Domain.Repositories.Autor;
using Biblioteca.Domain.Repositories.FormaCompra;

namespace Biblioteca.Application.UseCases.Livro
{
    public class LivroUseCase : ILivroUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAutorReadOnlyRepository _autorReadOnlyRepository;
        private readonly IAssuntoReadOnlyRepository _assuntoReadOnlyRepository;
        private readonly IFormaCompraReadOnlyRepository _formaCompraReadOnlyRepository;

        public LivroUseCase(IMapper mapper,
                            IAutorReadOnlyRepository autorReadOnlyRepository,
                            IAssuntoReadOnlyRepository assuntoReadOnlyRepository,
                            IFormaCompraReadOnlyRepository formaCompraReadOnlyRepository)
        {
            _mapper = mapper;
            _autorReadOnlyRepository = autorReadOnlyRepository;
            _assuntoReadOnlyRepository = assuntoReadOnlyRepository;
            _formaCompraReadOnlyRepository = formaCompraReadOnlyRepository;
        }

        public async Task<ICollection<Livro_Autor>> AddAutores(IEnumerable<int> autoresIds)
        {
            var autores = await _autorReadOnlyRepository.GetAutorByIdsAsync(autoresIds);

            if (autores.Any())
                return autores.Select(autor => _mapper.Map<Livro_Autor>(autor!)).ToList();

            return null!;
        }

        public async Task<ICollection<Livro_Assunto>> AddAssuntos(IEnumerable<int> assuntosIds)
        {
            var assuntos = await _assuntoReadOnlyRepository.GetAssuntoByIdsAsync(assuntosIds);

            if (assuntos.Any())
                return assuntos.Select(assunto => _mapper.Map<Livro_Assunto>(assunto!)).ToList();

            return null!;
        }

        public async Task<ICollection<Livro_FormaCompra>> AddFormasCompras(IEnumerable<FormasComprasRequest> formasCompras)
        {
            var formaComprasIds = formasCompras.Select(x => x.CodFo).ToList();

            var formaCompras = await _formaCompraReadOnlyRepository.GetFormaComprasByIdsAsync(formaComprasIds);

            var result = new List<Livro_FormaCompra>();

            if (formaCompras.Any())
            {
                foreach (var forma in formaCompras)
                {
                    var requestFormaCompra = formasCompras.FirstOrDefault(x => x.CodFo == forma!.CodFo);

                    result.Add(new Livro_FormaCompra
                    {
                        FormaCompra_CodFo = forma!.CodFo,
                        Preco = requestFormaCompra!.Preco
                    });
                }
            }

            return result;
        }
    }
}
