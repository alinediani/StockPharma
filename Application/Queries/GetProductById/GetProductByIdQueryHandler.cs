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
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, RawMaterialsViewModel>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public GetClientByIdQueryHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<RawMaterialsViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
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
                rawMaterial.Expiration
                );

            return rawMaterialsViewModel;
        }
    }
}
