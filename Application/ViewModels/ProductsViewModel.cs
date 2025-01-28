using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel(int id, string name, string description, List<RawMaterialEntity> rawMaterial, double price, int amount)
        {
            Id = id;
            Name = name;
            Description = description;
            RawMaterial = rawMaterial;
            Price = price;
            Amount = amount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RawMaterialEntity> RawMaterial { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
