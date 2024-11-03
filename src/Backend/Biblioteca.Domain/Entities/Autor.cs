namespace Biblioteca.Domain.Entities
{
    public class Autor
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }
    }
}
