using Application.ViewModels;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductRawMaterialViewModel> RawMaterials { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }


}
