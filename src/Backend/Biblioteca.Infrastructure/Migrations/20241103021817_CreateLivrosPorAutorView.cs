using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateLivrosPorAutorView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW LivrosPorAutorView AS
                                    SELECT a.Nome as NomeAutor
                                          ,a.CodAu
                                          ,l.Titulo
	                                      ,l.Editora 
	                                      ,l.Edicao 
	                                      ,l.AnoPublicacao
	                                      ,STRING_AGG(asu.Descricao, ', ') AS Assuntos
                                      FROM Livro_Autor la
                                      JOIN dbo.Autor a on a.CodAu = la.Autor_CodAu
                                      JOIN dbo.Livro l on l.Codl = la.Livro_Codl
                                      JOIN dbo.Livro_Assunto las on las.Livro_Codl = l.Codl
                                      JOIN dbo.Assunto asu on asu.CodAs = las.Assunto_CodAs
                                      GROUP BY
                                         a.Nome
	                                    ,a.CodAu
                                        ,l.Titulo
                                        ,l.Editora
                                        ,l.Edicao
                                        ,l.AnoPublicacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS LivrosPorAutorView;");
        }
    }
}
