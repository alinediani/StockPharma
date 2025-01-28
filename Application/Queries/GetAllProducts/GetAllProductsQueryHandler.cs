using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductsViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var productsViewModel = products.Select((p => new ProductsViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Amount = p.Amount,
                RawMaterials = p.ProductRawMaterials.Select(rm => new ProductRawMaterialViewModel
                {
                    RawMaterialId = rm.RawMaterialId,
                    RawMaterialName = rm.RawMaterial.Name,
                    Quantity = rm.Quantity
                }).ToList()
            }
            )).ToList();

            return productsViewModel;
        }
    }
}
