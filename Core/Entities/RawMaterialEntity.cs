using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RawMaterialEntity : BaseEntity
    {
        public RawMaterialEntity(string name, string description, string supplier, float amount, int uom, string expiration)
        {
            Name = name;
            Description = description;
            SupplierId = supplier;
            Amount = amount;
            UoM = uom;
            Expiration = expiration;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public float Amount { get; set; }
        public int UoM { get; set; }
        public string Expiration { get; set; }
    }
}
