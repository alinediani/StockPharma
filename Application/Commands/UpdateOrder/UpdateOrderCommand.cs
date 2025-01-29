using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public List<ProductEntity> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }
}
