using MediatR;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;

namespace Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IClientRepository _clientRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IOrderProductRepository orderProductRepository,
            IClientRepository clientRepository)
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.ClientId);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found.");
            }

            var orderProducts = new List<OrderProductEntity>();

            foreach (var product in request.Products)
            {
                var relation = new OrderProductEntity
                {
                    ProductId = product.ProductId
                };

                orderProducts.Add(relation);
            }

            var order = new OrderEntity(
                client,
                orderProducts,
                request.Amount,
                request.OrderDate,
                request.TotalCoast);

            await _orderRepository.AddAsync(order);

            return Unit.Value;
        }
    }
}
