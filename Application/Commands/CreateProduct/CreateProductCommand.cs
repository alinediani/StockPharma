using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using MediatR;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RawMaterialEntity> RawMaterial { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
