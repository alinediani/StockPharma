using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class RawMaterialEntity : BaseEntity
    {
        public RawMaterialEntity(string name, string description, string supplierId, float amount, int uoM, DateTime expiration)
        {
            Name = name;
            Description = description;
            SupplierId = supplierId;
            Amount = amount;
            UoM = uoM;
            Expiration = expiration;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public float Amount { get; set; }
        public int UoM { get; set; }
        public DateTime Expiration { get; set; }
        public ICollection<ProductRawMaterialEntity> ProductRawMaterials { get; set; } = new List<ProductRawMaterialEntity>();
    }
}
