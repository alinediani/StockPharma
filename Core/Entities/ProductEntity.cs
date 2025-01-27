using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(string name, string description, List<RawMaterialEntity> rawMaterial, double price, int amount)
        {
            Name = name;
            Description = description;
            RawMaterial = rawMaterial;
            Price = price;
            Amount = amount;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<RawMaterialEntity> RawMaterial { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
