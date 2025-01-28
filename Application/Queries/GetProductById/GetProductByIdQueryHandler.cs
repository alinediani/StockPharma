using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.ViewModels;

namespace Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductsViewModel>
    {
        private readonly IProductRepository _rawMaterialRepository;
        public GetProductByIdQueryHandler(IProductRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<ProductsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var rawMaterial = await _rawMaterialRepository.GetByIdAsync(request.Id);

            if (rawMaterial == null) return null;

            var rawMaterialsViewModel = new ProductsViewModel(
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
