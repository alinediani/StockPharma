using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            order.Client = request.Client;
            order.Products = request.Products;
            order.Amount = request.Amount;
            order.OrderDate = request.OrderDate;
            order.TotalCoast = request.TotalCoast;

            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
