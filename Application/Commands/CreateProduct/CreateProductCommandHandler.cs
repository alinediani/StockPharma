using MediatR;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;
using System.Collections.Generic;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRawMaterialRepository _productRawMaterialRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductRawMaterialRepository productRawMaterialRepository)
        {
            _productRepository = productRepository;
            _productRawMaterialRepository = productRawMaterialRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productRawMaterials = new List<ProductRawMaterialEntity>();

            foreach (var rawMaterialDto in request.RawMaterials)
            {
                var productRawMaterial = new ProductRawMaterialEntity
                {
                    RawMaterialId = rawMaterialDto.RawMaterialId
                };
                productRawMaterials.Add(productRawMaterial);
            }

            var product = new ProductEntity(
                request.Name,
                request.Description,
                productRawMaterials,
                request.Price,
                request.Amount
            );

            await _productRepository.AddAsync(product);

            foreach (var productRawMaterial in productRawMaterials)
            {
                productRawMaterial.ProductId = product.Id;
                await _productRawMaterialRepository.AddProductRawMaterialAsync(productRawMaterial);
            }

            return product.Id;
        }
    }
}
