using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductsViewModel>>
    {
        private readonly IProductRepository _rawMaterialRepository;
        public GetAllProductsQueryHandler(IProductRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<List<ProductsViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var rawMaterials = await _rawMaterialRepository.GetAllAsync();

            var rawMaterialsViewModel = rawMaterials
                .Select(r => new ProductsViewModel(r.Id,r.Name,r.Description,r.SupplierId,r.Amount,r.UoM,r.Expiration))
                .ToList();

            return rawMaterialsViewModel;
        }
    }
}
