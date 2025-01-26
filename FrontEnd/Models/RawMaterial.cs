using System.ComponentModel.DataAnnotations;

namespace FrontEnd.models
{
    public class RawMaterial
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Precisa de no minimo 4 caracteres")]
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public string Supplier { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O valor da quantidade deve ser maior ou igual a 0.")]
        public int Amount { get; set; } = 0;
        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        public DateTime? Expiration { get; set; }
    }
}
