using Biblioteca.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static async Task MigrateAsync(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<BibliotecaDbContext>();
            await runner.Database.MigrateAsync();
        }
    }
}
