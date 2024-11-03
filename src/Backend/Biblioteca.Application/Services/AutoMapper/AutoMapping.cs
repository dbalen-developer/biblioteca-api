using AutoMapper;
using Biblioteca.Communication.Requests;
using Biblioteca.Communication.Responses;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            DomainToDomain();
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<PostAssuntoRequest, Assunto>();
            CreateMap<PutAssuntoRequest, Assunto>();

            CreateMap<PostAutorRequest, Autor>();
            CreateMap<PutAutorRequest, Autor>();

            CreateMap<PostLivroRequest, Livro>();
            CreateMap<PutLivroRequest, Livro>();
        }

        private void DomainToDomain()
        {
            CreateMap<Autor, Livro_Autor>()
                .ForMember(dest => dest.Autor_CodAu, opt => opt.MapFrom(src => src.CodAu));

            CreateMap<Assunto, Livro_Assunto>()
                .ForMember(dest => dest.Assunto_CodAs, opt => opt.MapFrom(src => src.CodAs));

            CreateMap<FormaCompra, Livro_FormaCompra>()
                .ForMember(dest => dest.FormaCompra_CodFo, opt => opt.MapFrom(src => src.CodFo));
        }

        private void DomainToResponse()
        {
            CreateMap<Autor, GetAutoresResponse>();

            CreateMap<Assunto, GetAssuntosResponse>();

            CreateMap<FormaCompra, GetFormasComprasResponse>();

            CreateMap<LivrosPorAutorView, GetReportLivrosPorAutorResponse>();

            CreateMap<Livro_Autor, GetAutoresResponse>()
                .ForMember(dest => dest.CodAu, opt => opt.MapFrom(src => src.Autor_CodAu))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Autor != null ? src.Autor.Nome : null));

            CreateMap<Livro_Assunto, GetAssuntosResponse>()
                .ForMember(dest => dest.CodAs, opt => opt.MapFrom(src => src.Assunto_CodAs))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Assunto != null ? src.Assunto.Descricao : null));

            CreateMap<Livro_FormaCompra, GetLivroFormasComprasResponse>()
                .ForMember(dest => dest.CodFo, opt => opt.MapFrom(src => src.FormaCompra_CodFo))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.FormaCompra != null ? src.FormaCompra.Descricao : null))
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Preco));

            CreateMap<Livro, GetLivrosResponse>()
                .ForMember(dest => dest.Autores, opt => opt.MapFrom(src => src.Livro_Autores))
                .ForMember(dest => dest.Assuntos, opt => opt.MapFrom(src => src.Livro_Assuntos))
                .ForMember(dest => dest.FormasCompra, opt => opt.MapFrom(src => src.Livro_FormaCompras));
        }
    }
}
