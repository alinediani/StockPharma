using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RawMaterialEntity> RawMaterial { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
