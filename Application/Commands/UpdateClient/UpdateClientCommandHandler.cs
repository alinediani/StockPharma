using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Application.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;
        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found.");
            }

            client.Name = request.Name;
            client.CPF = request.CPF;
            client.Address = request.Address;
            client.Telephone = request.Telephone;
            client.Email = request.Email;

            await _clientRepository.UpdateAsync(client);

            return Unit.Value;
        }
    }
}
