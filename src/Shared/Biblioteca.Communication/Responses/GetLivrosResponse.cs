namespace Biblioteca.Communication.Responses
{
    public class GetLivrosResponse
    {
        public int Codl { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }

        public IEnumerable<GetAutoresResponse> Autores { get; set; }
        public IEnumerable<GetAssuntosResponse> Assuntos { get; set; }
        public IEnumerable<GetLivroFormasComprasResponse> FormasCompra { get; set; }

    }
}
