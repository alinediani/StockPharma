using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel(int id, string name, double price, int amount)
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }

    public class ProductRawMaterialViewModel
    {
        public ProductRawMaterialViewModel(int rawMaterialId, float quantity)
        {
            RawMaterialId = rawMaterialId;
            Quantity = quantity;
        }

        public int RawMaterialId { get; set; }
        public float Quantity { get; set; }
    }
}
