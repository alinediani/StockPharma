using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Application.ViewModels;

namespace Application.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientsViewModel>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientsViewModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null) return null;

            var clientsViewModel = new ClientsViewModel(
                client.Id,
                client.Name,
                client.CPF,
                client.Address,
                client.Telephone,
                client.Email
                );

            return clientsViewModel;
        }
    }
}
