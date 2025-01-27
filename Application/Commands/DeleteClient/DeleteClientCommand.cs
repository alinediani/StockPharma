using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteClient
{
    public class DeleteClientsCommand : IRequest<Unit>
    {
        public DeleteClientsCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
