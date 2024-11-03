using Biblioteca.Domain.Repositories.Assunto;
using Biblioteca.Domain.Repositories.Autor;
using Biblioteca.Domain.Repositories.FormaCompra;
using Biblioteca.Domain.Repositories.Livro;
using Biblioteca.Domain.Repositories.LivroAssunto;
using Biblioteca.Domain.Repositories.LivroAutor;
using Biblioteca.Domain.Repositories.LivroFormaCompra;
using Biblioteca.Domain.Repositories.Report;
using Biblioteca.Infrastructure.DataAccess;
using Biblioteca.Infrastructure.DataAccess.Repositories.Assunto;
using Biblioteca.Infrastructure.DataAccess.Repositories.Autor;
using Biblioteca.Infrastructure.DataAccess.Repositories.FormaCompra;
using Biblioteca.Infrastructure.DataAccess.Repositories.Livro;
using Biblioteca.Infrastructure.DataAccess.Repositories.LivroAssunto;
using Biblioteca.Infrastructure.DataAccess.Repositories.LivroAutor;
using Biblioteca.Infrastructure.DataAccess.Repositories.LivroFormaCompra;
using Biblioteca.Infrastructure.DataAccess.Repositories.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContextSqlServer(services, configuration);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAutorReadOnlyRepository, AutorRepository>();
            services.AddScoped<IAutorWriteOnlyRepository, AutorRepository>();

            services.AddScoped<IAssuntoReadOnlyRepository, AssuntoRepository>();
            services.AddScoped<IAssuntoWriteOnlyRepository, AssuntoRepository>();

            services.AddScoped<IFormaCompraReadOnlyRepository, FormaCompraRepository>();

            services.AddScoped<ILivroReadOnlyRepository, LivroRepository>();
            services.AddScoped<ILivroWriteOnlyRepository, LivroRepository>();

            services.AddScoped<ILivroAutorWriteOnlyRepository, LivroAutorRepository>();
            services.AddScoped<ILivroAssuntoWriteOnlyRepository, LivroAssuntoRepository>();
            services.AddScoped<ILivroFormaCompraWriteOnlyRepository, LivroFormaCompraRepository>();

            services.AddScoped<IReportReadOnlyRepository, ReportRepository>();
        }

        private static void AddDbContextSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BibliotecaDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connString);
            });
        }
    }
}
