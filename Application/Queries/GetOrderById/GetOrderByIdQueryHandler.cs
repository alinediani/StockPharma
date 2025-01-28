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
        private readonly IOrderRepository _rawMaterialRepository;
        public GetOrderByIdQueryHandler(IOrderRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<OrdersViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var rawMaterial = await _rawMaterialRepository.GetByIdAsync(request.Id);

            if (rawMaterial == null) return null;

            var rawMaterialsViewModel = new OrdersViewModel(
                rawMaterial.Id,
                rawMaterial.Name,
                rawMaterial.Description,
                rawMaterial.SupplierId,
                rawMaterial.Amount,
                rawMaterial.UoM,
                rawMaterial.Expiration
                );

            return rawMaterialsViewModel;
        }
    }
}
