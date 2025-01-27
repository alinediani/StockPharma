using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.UpdateRawMaterial
{
    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, Unit>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public UpdateProductsCommandHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<Unit> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
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
