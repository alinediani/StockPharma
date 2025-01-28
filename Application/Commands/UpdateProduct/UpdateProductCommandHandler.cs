using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
            product.RawMaterial = request.RawMaterial;
            product.Price = request.Price;
            product.Amount = request.Amount;

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
