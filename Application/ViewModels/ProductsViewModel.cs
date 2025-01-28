using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel(int id, string name, string description, List<ProductRawMaterialViewModel> rawMaterials, double price, int amount)
        {
            Id = id;
            Name = name;
            Description = description;
            RawMaterials = rawMaterials;
            Price = price;
            Amount = amount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductRawMaterialViewModel> RawMaterials { get; set; }
        public double Price { get; set; } 
        public int Amount { get; set; }
    }

    public class ProductRawMaterialViewModel
    {
        public ProductRawMaterialViewModel(int rawMaterialId, string rawMaterialName, float quantity)
        {
            RawMaterialId = rawMaterialId;
            RawMaterialName = rawMaterialName;
            Quantity = quantity;
        }

        public int RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public float Quantity { get; set; } // Quantidade da matéria-prima usada no produto
    }
}
