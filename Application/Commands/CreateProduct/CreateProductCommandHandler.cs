using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.CreateProduct;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity(request.Name, request.Description, request.SupplierId, request.Amount, request.UoM, request.Expiration);

            await _productRepository.AddAsync(product);

            return product.Id;
        }
    }
}
