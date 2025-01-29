using Application.Queries.GetAllOrders;
using Application.ViewModels;
using Core.Repositories;
using MediatR;

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

        var ordersViewModel = orders.Select(o => new OrdersViewModel(
            o.Id, // Passando o ID da ordem
            new ClientsViewModel(
                o.Client.Id, // Passando o ID do cliente
                o.Client.Name, // Nome do cliente
                o.Client.CPF, // CPF do cliente
                o.Client.Address, // Endereço do cliente
                o.Client.Telephone, // Telefone do cliente
                o.Client.Email // Email do cliente
            ),
            o.OrderProducts.Select(p => new OrderProductViewModel(
                p.Id,
                p.ProductId, // ID do produto
                p.Product.Name, // Nome do produto
                p.Quantity // Quantidade do produto
            )).ToList(),
            o.Amount, // Valor total da ordem
            o.OrderDate, // Data da ordem
            o.TotalCoast // Custo total da ordem
        )).ToList();

        return ordersViewModel;
    }
}
