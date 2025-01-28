using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrdersViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrdersViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            var ordersViewModel = orders
                .Select(r => new OrdersViewModel(r.Id,r.Name,r.Description,r.SupplierId,r.Amount,r.UoM,r.Expiration))
                .ToList();

            return ordersViewModel;
        }
    }
}
