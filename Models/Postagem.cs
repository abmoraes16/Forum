using System;

namespace ProjetoForum.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public int IdTopico { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}