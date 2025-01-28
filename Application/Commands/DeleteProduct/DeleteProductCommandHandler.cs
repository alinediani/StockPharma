using MediatR;
using System;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRawMaterialRepository _productRawMaterialRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository, IProductRawMaterialRepository productRawMaterialRepository)
        {
            _productRepository = productRepository;
            _productRawMaterialRepository = productRawMaterialRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            foreach (var productRawMaterial in product.ProductRawMaterials)
            {
                await _productRawMaterialRepository.DeleteProductRawMaterialAsync(product.Id, productRawMaterial.RawMaterialId);
            }

            await _productRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
