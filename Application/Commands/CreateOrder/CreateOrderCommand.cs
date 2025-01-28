using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using MediatR;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public List<ProductEntity> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }
}
