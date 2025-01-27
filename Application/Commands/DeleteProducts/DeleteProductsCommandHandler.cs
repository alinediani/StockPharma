using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.DeleteProduct
{
    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductsCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            await _productRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
