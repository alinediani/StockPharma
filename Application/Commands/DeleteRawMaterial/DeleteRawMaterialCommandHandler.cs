using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.DeleteRawMaterial
{
    public class DeleteRawMaterialCommandHandler : IRequestHandler<DeleteRawMaterialCommand, Unit>
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        public DeleteRawMaterialCommandHandler(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<Unit> Handle(DeleteRawMaterialCommand request, CancellationToken cancellationToken)
        {
            var rawMaterial = await _rawMaterialRepository.GetByIdAsync(request.Id);

            await _rawMaterialRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
