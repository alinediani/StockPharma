using System;
using System.Collections.Generic;
using MediatR;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int ClientId { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }

    public class OrderProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
