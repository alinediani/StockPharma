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
            // Obtém o pedido a ser atualizado
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            // Atualiza os campos principais do pedido
            order.ClientId = request.ClientId;  // Atualiza apenas o ClientId
            order.Amount = request.Amount;
            order.OrderDate = request.OrderDate;
            order.TotalCoast = request.TotalCoast;

            var currentOrderProducts = order.OrderProducts.ToList(); // Produtos atuais no pedido
            var updatedProducts = request.Products; // Produtos que vêm no comando

            // Remover produtos que não estão mais presentes no pedido
            foreach (var current in currentOrderProducts)
            {
                if (!updatedProducts.Any(u => u.Id == current.ProductId))
                {
                    await _orderProductRepository.DeleteOrderProductAsync(order.Id, current.ProductId);
                }
            }

            // Adicionar novos produtos ao pedido
            foreach (var updated in updatedProducts)
            {
                if (!currentOrderProducts.Any(c => c.ProductId == updated.Id))
                {
                    var newRelation = new OrderProductEntity
                    {
                        OrderId = order.Id,
                        ProductId = updated.Id,
                        Quantity = updated.Quantity  // Se precisar atualizar a quantidade
                    };
                    await _orderProductRepository.AddOrderProductAsync(newRelation);
                }
            }

            // Atualiza o pedido no repositório
            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }

}
