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

            // Limpeza e atualização dos materiais-primas
            var currentRawMaterials = product.ProductRawMaterials.ToList();

            // Identifica e adiciona novos materiais-primas
            var rawMaterialsToAdd = request.RawMaterials
                .Where(updated => !currentRawMaterials.Any(current => current.RawMaterialId == updated.RawMaterialId))
                .ToList();

            var newProductRawMaterials = rawMaterialsToAdd.Select(updated => new ProductRawMaterialEntity
            {
                ProductId = product.Id,
                RawMaterialId = updated.RawMaterialId,
                Quantity = updated.Quantity // Agora usando quantidade do modelo
            }).ToList();

            // Adiciona novos materiais-primas no repositório
            if (newProductRawMaterials.Any())
            {
                await _productRawMaterialRepository.AddProductRawMaterialAsync(newProductRawMaterials);
            }

            // Atualiza o produto no repositório
            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }

}
