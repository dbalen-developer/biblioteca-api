namespace Biblioteca.Communication.Requests
{
    public class LivroRequest
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public IEnumerable<int> AutoresIds { get; set; }
        public IEnumerable<int> AssuntosIds { get; set; }
        public IEnumerable<FormasComprasRequest> FormasCompras { get; set; }
    }
}
