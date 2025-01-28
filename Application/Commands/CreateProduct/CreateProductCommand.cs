using System.Collections.Generic;
using MediatR;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductRawMaterialDto> RawMaterials { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }

    public class ProductRawMaterialDto
    {
        public int RawMaterialId { get; set; }
        public float Quantity { get; set; }
    }
}
