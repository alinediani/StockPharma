using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            
            var client = new ClientEntity(
                request.Name,
                request.CPF,
                request.Address,
                request.Telephone,
                request.Email,
                new List<OrderEntity>() 
            );

            
            await _clientRepository.AddAsync(client);

            
            return client.Id;
        }
    }
}
