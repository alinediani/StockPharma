using System.Collections.Generic;

namespace Core.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(
            string name,
            string description,
            List<ProductRawMaterialEntity> productRawMaterials,
            double price,
            int amount)
        {
            Name = name;
            Description = description;
            ProductRawMaterials = productRawMaterials ?? new List<ProductRawMaterialEntity>();
            Price = price;
            Amount = amount;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductRawMaterialEntity> ProductRawMaterials { get; set; } = new List<ProductRawMaterialEntity>();
        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
