using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.ViewModels;

namespace Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductsViewModel>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductsViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) return null;

            var productsViewModel = new ProductsViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.RawMaterial,
                product.Price,
                product.Amount
                );

            return productsViewModel;
        }
    }
}
