using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Price { get; set; }

        public List<RawMaterial> RawMaterials { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int Amount { get; set; }
    }

    public class ProductRawMaterialInsert 
    { 
        public int RawMaterialId { get; set; }
        public float Quantity { get; set; }
    }

    public class ProductInsert 
    {
        public string name { get; set; }
        public string description { get; set; }     

        public List<ProductRawMaterialInsert> rawMaterials {  get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }

    public class ProductMapper
    {
        // Método para converter um Product para ProductInsert
        
        public static ProductInsert ConvertToProductInsert(Product product)
        {
            return new ProductInsert
            {
                name = product.Name,
                description = product.Description,
                Price = product.Price,
                Amount = product.Amount,

                // Converter cada RawMaterial em um ProductRawMaterialInsert
                rawMaterials = product.RawMaterials.Select(rm => new ProductRawMaterialInsert
                {
                    RawMaterialId = rm.Id,  // Mapeia o Id da matéria-prima
                    Quantity = rm.Amount    // Mapeia a quantidade da matéria-prima (você pode ajustar conforme necessário)
                }).ToList() // Cria uma lista de ProductRawMaterialInsert
            };
        }
    }
}
