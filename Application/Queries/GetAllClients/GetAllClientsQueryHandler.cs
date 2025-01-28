using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllRawMaterials
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<RawMaterialsViewModel>>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public GetAllClientsQueryHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<List<RawMaterialsViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var rawMaterials = await _rawMaterialRepository.GetAllAsync();

            var rawMaterialsViewModel = rawMaterials
                .Select(r => new RawMaterialsViewModel(r.Id,r.Name,r.Description,r.SupplierId,r.Amount,r.UoM,r.Expiration))
                .ToList();

            return rawMaterialsViewModel;
        }
    }
}
