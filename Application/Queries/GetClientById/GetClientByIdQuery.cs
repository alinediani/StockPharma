using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientsViewModel>
    {
        public GetClientByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
