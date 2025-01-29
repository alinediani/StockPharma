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

            // Atualiza os campos simples do produto
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Amount = request.Amount;

            // Atualiza os materiais-primas do produto
            var currentRawMaterials = product.ProductRawMaterials.ToList();

            // Remover materiais-primas que não estão mais presentes
            var rawMaterialsToRemove = currentRawMaterials
                .Where(current => !request.RawMaterials.Any(updated => updated.RawMaterialId == current.RawMaterialId))
                .ToList();

            // Deleta os materiais-primas removidos
            foreach (var rawMaterialToRemove in rawMaterialsToRemove)
            {
                await _productRawMaterialRepository.DeleteProductRawMaterialAsync(product.Id, rawMaterialToRemove.RawMaterialId);
            }

            // Identifica novos materiais-primas a serem adicionados
            var rawMaterialsToAdd = request.RawMaterials
                .Where(updated => !currentRawMaterials.Any(current => current.RawMaterialId == updated.RawMaterialId))
                .ToList();

            // Adiciona os novos materiais-primas
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
