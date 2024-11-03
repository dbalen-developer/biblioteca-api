﻿namespace Biblioteca.Communication.Responses
{
    public class GetReportLivrosPorAutorResponse
    {
        public string NomeAutor { get; set; }
        public int CodAu { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public string Assuntos { get; set; }
    }
}
