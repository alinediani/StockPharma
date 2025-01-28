using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.Commands.DeleteClient;

namespace Application.Commands.DeleteClients
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            await _clientRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
