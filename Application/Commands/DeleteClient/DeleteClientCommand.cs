using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public DeleteClientCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
