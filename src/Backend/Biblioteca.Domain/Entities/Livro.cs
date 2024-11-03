namespace Biblioteca.Domain.Entities
{
    public class Livro
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }
        public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }
        public virtual ICollection<Livro_FormaCompra> Livro_FormaCompras { get; set; }
    }
}
