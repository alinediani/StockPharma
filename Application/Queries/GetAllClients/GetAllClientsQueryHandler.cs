using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.ViewModels;
using Core.Repositories;

namespace Application.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientsViewModel>>
    {
        private readonly IClientRepository _clientRepository;
        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientsViewModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();

            var clientsViewModel = clients
                .Select(c => new ClientsViewModel(c.Id,c.Name,c.CPF,c.Address,c.Telephone,c.Email))
                .ToList();

            return clientsViewModel;
        }
    }
}
