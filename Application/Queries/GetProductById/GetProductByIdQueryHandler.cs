using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductsViewModel>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) return null;

            var productsViewModel = new ProductsViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.ProductRawMaterials.Select(rm => new ProductRawMaterialViewModel(
                    rm.ProductRawMaterialId,
                    rm.RawMaterialId,
                    rm.RawMaterial.Name,
                    rm.Quantity
                )).ToList(),
                product.Price,
                product.Amount
            );

            return productsViewModel;
        }
    }

}
