using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<ClientsViewModel>>
    {
        public GetAllClientsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
