using MediatR;
using System;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Entities;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRawMaterialRepository _productRawMaterialRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository, IProductRawMaterialRepository productRawMaterialRepository)
        {
            _productRepository = productRepository;
            _productRawMaterialRepository = productRawMaterialRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Amount = request.Amount;

            var currentRawMaterials = product.ProductRawMaterials;
            var updatedRawMaterials = request.RawMaterial;

            foreach (var current in currentRawMaterials)
            {
                if (!updatedRawMaterials.Any(u => u.Id == current.RawMaterialId))
                {
                    await _productRawMaterialRepository.DeleteProductRawMaterialAsync(product.Id, current.RawMaterialId);
                }
            }

            foreach (var updated in updatedRawMaterials)
            {
                if (!currentRawMaterials.Any(c => c.RawMaterialId == updated.Id))
                {
                    var newRelation = new ProductRawMaterialEntity
                    {
                        ProductId = product.Id,
                        RawMaterialId = updated.Id
                    };
                    await _productRawMaterialRepository.AddProductRawMaterialAsync(newRelation);
                }
            }

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
