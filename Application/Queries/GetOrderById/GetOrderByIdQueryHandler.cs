using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.ViewModels;

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
                order.Client,
                order.Products,
                order.Amount,
                order.OrderDate,
                order.TotalCoast
                );

            return ordersViewModel;
        }
    }
}
