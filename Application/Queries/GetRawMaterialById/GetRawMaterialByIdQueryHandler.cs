using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.ViewModels;

namespace Application.Queries.GetRawMaterialById
{
    public class GetRawMaterialByIdQueryHandler : IRequestHandler<GetRawMaterialByIdQuery, RawMaterialsViewModel>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public GetRawMaterialByIdQueryHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<RawMaterialsViewModel> Handle(GetRawMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var rawMaterial = await _rawMaterialRepository.GetByIdAsync(request.Id);

            if (rawMaterial == null) return null;

            var rawMaterialsViewModel = new RawMaterialsViewModel(
                rawMaterial.Id,
                rawMaterial.Name,
                rawMaterial.Description,
                rawMaterial.SupplierId,
                rawMaterial.Amount,
                rawMaterial.UoM,
                rawMaterial.Expiration,
                rawMaterial.ProductRawMaterials.Select(rm => new ProductRawMaterialViewModel(
                    rm.RawMaterialId,
                    rm.Quantity
                )).ToList()
            );

            return rawMaterialsViewModel;
        }
    }

}
