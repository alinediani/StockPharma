using MediatR;
using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;

namespace Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            order.Client = request.Client;
            order.Amount = request.Amount;
            order.OrderDate = request.OrderDate;
            order.TotalCoast = request.TotalCoast;

            var currentOrderProducts = order.OrderProducts;
            var updatedProducts = request.Products;

            foreach (var current in currentOrderProducts)
            {
                if (!updatedProducts.Any(u => u.Id == current.ProductId))
                {
                    await _orderProductRepository.DeleteOrderProductAsync(order.Id, current.ProductId);
                }
            }

            foreach (var updated in updatedProducts)
            {
                if (!currentOrderProducts.Any(c => c.ProductId == updated.Id))
                {
                    var newRelation = new OrderProductEntity
                    {
                        OrderId = order.Id,
                        ProductId = updated.Id
                    };
                    await _orderProductRepository.AddOrderProductAsync(newRelation);
                }
            }

            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
