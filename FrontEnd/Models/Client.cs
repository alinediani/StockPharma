using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "O CPF deve conter 11 dígitos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
    }
}
