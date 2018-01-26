using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoForum.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Nome do usuário")]
        [Required(ErrorMessage="Esse campo não pode ficar vazio")]    //<- not null :: Nome
        [MinLength(2,ErrorMessage="Você deve inserir um nome com mais de 2 caracteres")]
        [MaxLength(10,ErrorMessage="Você não pode inserir um nome com mais de 10 caracteres")]
        public string Nome { get; set; }
        public string Login { get; set; }
        //[RegularExpression(@"^*[A-Z]$",
        //ErrorMessage="Não é permitido caracteres especiais e espaços.")]
        [MinLength(8,ErrorMessage="Tamanho minimo de 8 caracteres")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}