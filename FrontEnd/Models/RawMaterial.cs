using System.ComponentModel.DataAnnotations;
using FrontEnd.Enums;

namespace FrontEnd.Models
{
    public class RawMaterial
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MinLength(4, ErrorMessage = "Precisa de no minimo 4 caracteres")]
        public string Name { get; set; }
        public string Description { get; set; } = "";
        [Required]
        public string SupplierId { get; set; }
        [Required(ErrorMessage = "O fornecedor é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O valor da quantidade deve ser maior ou igual a 0.")]
        public int Amount { get; set; } = 0;
        public UoM UoM { get; set; }
        public DateTime? Expiration { get; set; }


    }
}
