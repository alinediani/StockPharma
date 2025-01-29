using Application.Queries.GetAllProducts;
using Application.ViewModels;
using Core.Repositories;
using MediatR;

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

        var productsViewModel = products.Select(p => new ProductsViewModel(
            p.Id, 
            p.Name, 
            p.Description,
            p.ProductRawMaterials.Select(rm => new ProductRawMaterialViewModel(
                rm.ProductRawMaterialId,
                rm.RawMaterialId,
                rm.RawMaterial.Name,
                rm.Quantity
            )).ToList(),
            p.Price,
            p.Amount
        )).ToList();

        return productsViewModel;
    }
}
