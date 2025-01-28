using MediatR;
using System;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            foreach (var orderProduct in order.OrderProducts)
            {
                await _orderProductRepository.DeleteOrderProductAsync(order.Id, orderProduct.ProductId);
            }

            await _orderRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
