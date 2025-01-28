using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductsViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var productsViewModel = products
                .Select(p => new ProductsViewModel(p.Id,p.Name,p.Description,p.RawMaterial,p.Price,p.Amount))
                .ToList();

            return productsViewModel;
        }
    }
}
