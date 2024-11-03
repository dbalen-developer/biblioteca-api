namespace Biblioteca.Domain.Entities
{
    public class FormaCompra
    {
        public int CodFo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Livro_FormaCompra> Livro_FormaCompras { get; set; }
    }
}
