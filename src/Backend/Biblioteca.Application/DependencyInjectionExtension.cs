using Biblioteca.Application.Services.AutoMapper;
using Biblioteca.Application.UseCases.Assunto.DeleteAssunto;
using Biblioteca.Application.UseCases.Assunto.GetAssuntos;
using Biblioteca.Application.UseCases.Assunto.PostAssunto;
using Biblioteca.Application.UseCases.Assunto.PutAssunto;
using Biblioteca.Application.UseCases.Autor.DeleteAutor;
using Biblioteca.Application.UseCases.Autor.GetAutores;
using Biblioteca.Application.UseCases.Autor.PostAutore;
using Biblioteca.Application.UseCases.Autor.PutAutor;
using Biblioteca.Application.UseCases.FormaCompra.GetFormasCompras;
using Biblioteca.Application.UseCases.Livro;
using Biblioteca.Application.UseCases.Livro.DeleteLivro;
using Biblioteca.Application.UseCases.Livro.GetLivros;
using Biblioteca.Application.UseCases.Livro.PostLivro;
using Biblioteca.Application.UseCases.Livro.PutLivro;
using Biblioteca.Application.UseCases.Report.GetReportLivrosPorAutor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetAutoresUseCase, GetAutoresUseCase>();
            services.AddScoped<IPostAutorUseCase, PostAutorUseCase>();
            services.AddScoped<IDeleteAutorUseCase, DeleteAutorUseCase>();
            services.AddScoped<IPutAutorUseCase, PutAutorUseCase>();

            services.AddScoped<IGetAssuntosUseCase, GetAssuntosUseCase>();
            services.AddScoped<IPostAssuntoUseCase, PostAssuntoUseCase>();
            services.AddScoped<IDeleteAssuntoUseCase, DeleteAssuntoUseCase>();
            services.AddScoped<IPutAssuntoUseCase, PutAssuntoUseCase>();

            services.AddScoped<IGetFormasComprasUseCase, GetFormasComprasUseCase>();

            services.AddScoped<ILivroUseCase, LivroUseCase>();

            services.AddScoped<IGetLivrosUseCase, GetLivrosUseCase>();
            services.AddScoped<IDeleteLivroUseCase, DeleteLivroUseCase>();
            services.AddScoped<IPostLivroUseCase, PostLivroUseCase>();
            services.AddScoped<IPutLivroUseCase, PutLivroUseCase>();

            services.AddScoped<IGetReportLivrosPorAutorUseCase, GetReportLivrosPorAutorUseCase>();
        }
    }
}
