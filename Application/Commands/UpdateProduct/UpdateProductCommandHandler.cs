using MediatR;
using System;
using System.Linq;
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
            // Obtém o produto a ser atualizado
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Atualiza os campos do produto
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Amount = request.Amount;

            var currentRawMaterials = product.ProductRawMaterials.ToList(); // Crie uma cópia da lista de materiais-primas

            // Identificar e remover materiais-primas que não estão mais no pedido
            var rawMaterialsToRemove = currentRawMaterials
                .Where(current => !request.RawMaterials.Any(updated => updated.RawMaterialId == current.RawMaterialId))
                .ToList();

            foreach (var rawMaterialToRemove in rawMaterialsToRemove)
            {
                await _productRawMaterialRepository.DeleteProductRawMaterialAsync(product.Id, rawMaterialToRemove.RawMaterialId);
            }

            // Identificar e adicionar novos materiais-primas
            var rawMaterialsToAdd = request.RawMaterials
                .Where(updated => !currentRawMaterials.Any(current => current.RawMaterialId == updated.RawMaterialId))
                .ToList();

            foreach (var material in rawMaterialsToAdd)
            {
                var newProductRawMaterial = new ProductRawMaterialEntity
                {
                    ProductId = product.Id,
                    RawMaterialId = material.RawMaterialId,
                    Quantity = material.Quantity
                };
                await _productRawMaterialRepository.AddProductRawMaterialAsync(newProductRawMaterial);
            }

            // Atualiza o produto no repositório
            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }

}

