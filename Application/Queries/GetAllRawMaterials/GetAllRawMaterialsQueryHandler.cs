using Application.Queries.GetAllRawMaterials;
using Application.ViewModels;
using Core.Repositories;
using MediatR;

public class GetAllRawMaterialsQueryHandler : IRequestHandler<GetAllRawMaterialsQuery, List<RawMaterialsViewModel>>
{
    private readonly IRawMaterialRepository _rawMaterialRepository;

    public GetAllRawMaterialsQueryHandler(IRawMaterialRepository rawMaterialRepository)
    {
        _rawMaterialRepository = rawMaterialRepository;
    }

    public async Task<List<RawMaterialsViewModel>> Handle(GetAllRawMaterialsQuery request, CancellationToken cancellationToken)
    {
        var rawMaterials = await _rawMaterialRepository.GetAllAsync();

        var rawMaterialsViewModel = rawMaterials
            .Select(r => new RawMaterialsViewModel(
                r.Id, // Passando o ID da matéria-prima
                r.Name, // Nome da matéria-prima
                r.Description, // Descrição da matéria-prima
                r.SupplierId, // ID do fornecedor
                r.Amount, // Quantidade disponível
                r.UoM, // Unidade de medida
                r.Expiration, // Data de expiração
                r.ProductRawMaterials.Select(rm => new ProductRawMaterialViewModel(
                    rm.ProductRawMaterialId,
                    rm.RawMaterialId, // ID da matéria-prima no produto
                    rm.RawMaterial.Name, // Nome da matéria-prima no produto
                    rm.Quantity // Quantidade utilizada no produto
                )).ToList() // Lista das matérias-primas nos produtos
            )).ToList();

        return rawMaterialsViewModel;
    }
}
