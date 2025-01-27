using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.UpdateRawMaterial
{
    public class UpdateRawMaterialCommandHandler : IRequestHandler<UpdateRawMaterialCommand, Unit>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public UpdateRawMaterialCommandHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<Unit> Handle(UpdateRawMaterialCommand request, CancellationToken cancellationToken)
        {
            var rawMaterial = await _rawMaterialRepository.GetByIdAsync(request.Id);

            if (rawMaterial == null)
            {
                throw new InvalidOperationException("Raw material not found.");
            }

            rawMaterial.Name = request.Name;
            rawMaterial.Description = request.Description;
            rawMaterial.SupplierId = request.SupplierId;
            rawMaterial.Amount = request.Amount;
            rawMaterial.UoM = request.UoM;
            rawMaterial.Expiration = request.Expiration;

            await _rawMaterialRepository.UpdateAsync(rawMaterial);

            return Unit.Value;
        }
    }
}
