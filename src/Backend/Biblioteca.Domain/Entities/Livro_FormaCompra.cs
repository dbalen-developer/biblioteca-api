namespace Biblioteca.Domain.Entities
{
    public class Livro_FormaCompra
    {
        public int LivroCodL { get; set; }
        public int FormaCompra_CodFo { get; set; }
        public decimal Preco { get; set; }

        public virtual Livro Livro { get; set; }
        public virtual FormaCompra FormaCompra { get; set; }
    }
}
