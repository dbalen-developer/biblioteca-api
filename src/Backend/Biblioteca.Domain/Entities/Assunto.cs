namespace Biblioteca.Domain.Entities
{
    public class Assunto
    {
        public int CodAs { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }
    }
}
