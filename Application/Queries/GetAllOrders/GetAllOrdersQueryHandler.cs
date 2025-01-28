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
                .Select(o => new OrdersViewModel
                {
                    Id = o.Id,
                    Client = new ClientsViewModel
                    {
                        Id = o.Client.Id,
                        Name = o.Client.Name,
                        CPF = o.Client.CPF,
                        Address = o.Client.Address,
                        Telephone = o.Client.Telephone,
                        Email = o.Client.Email,
                        Orders = o.Client.Orders.Select(order => new OrdersViewModel
                        {
                            Id = order.Id,
                            Amount = order.Amount,
                            OrderDate = order.OrderDate,
                            TotalCoast = order.TotalCoast
                        }).ToList()
                    },
                    Products = o.Products.Select(p => new OrderProductViewModel
                    {
                        ProductId = p.ProductId,
                        ProductName = p.Product.Name,
                        Quantity = p.Quantity
                    }).ToList(),
                    Amount = o.Amount,
                    OrderDate = o.OrderDate,
                    TotalCoast = o.TotalCoast
                })
                .ToList();

            return ordersViewModel;
        }
    }
}
