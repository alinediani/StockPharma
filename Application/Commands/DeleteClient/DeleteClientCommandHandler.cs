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
    public class DeleteClientsCommandHandler : IRequestHandler<DeleteClientsCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientsCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientsCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            await _clientRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
