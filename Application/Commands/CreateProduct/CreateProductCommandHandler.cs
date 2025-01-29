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
            // Criar a lista de ProductRawMaterials
            var productRawMaterials = new List<ProductRawMaterialEntity>();

            // Adicionar os ProductRawMaterialEntity sem preencher o Id manualmente
            foreach (var rawMaterialDto in request.RawMaterials)
            {
                var productRawMaterial = new ProductRawMaterialEntity
                {
                    RawMaterialId = rawMaterialDto.RawMaterialId
                    // Não atribua explicitamente o Id
                };
                productRawMaterials.Add(productRawMaterial);
            }

            // Criar o produto
            var product = new ProductEntity(
                request.Name,
                request.Description,
                productRawMaterials,
                request.Price,
                request.Amount
            );

            // Adicionar o produto ao repositório
            await _productRepository.AddAsync(product);

            // Atribuir o ProductId aos ProductRawMaterialEntity após a criação do produto
            foreach (var productRawMaterial in productRawMaterials)
            {
                productRawMaterial.ProductId = product.Id;  // Atribuindo corretamente o ProductId
                // Não altere o Id, pois ele será gerado automaticamente
                await _productRawMaterialRepository.AddProductRawMaterialAsync(productRawMaterial);
            }

            return product.Id;  // Retorna o Id do produto criado
        }
    }
}
