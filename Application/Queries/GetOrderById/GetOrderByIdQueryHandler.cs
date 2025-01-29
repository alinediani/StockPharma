using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrdersViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrdersViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null) return null;

            var ordersViewModel = new OrdersViewModel(
                order.Id,
                new ClientsViewModel(
                    order.Client.Id,
                    order.Client.Name,
                    order.Client.CPF,
                    order.Client.Address,
                    order.Client.Telephone,
                    order.Client.Email),
                order.OrderProducts.Select(op => new OrderProductViewModel(
                    op.Id,
                    op.Product.Id,               // ID do produto
                    op.Product.Name,             // Nome do produto
                    op.Quantity                  // Quantidade do produto no pedido
                )).ToList(),
                order.Amount,
                order.OrderDate,
                order.TotalCoast
            );

            return ordersViewModel;
        }
    }
}
