using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateRawMaterial
{
    public class CreateRawMaterialCommandHandler : IRequestHandler<CreateRawMaterialCommand, int>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public CreateRawMaterialCommandHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<int> Handle(CreateRawMaterialCommand request, CancellationToken cancellationToken)
        {
            var rawMaterial = new RawMaterialEntity(request.Name, request.Description, request.SupplierId, request.Amount, request.UoM, request.Expiration);

            await _rawMaterialRepository.AddAsync(rawMaterial);

            return rawMaterial.Id;
        }
    }
}
