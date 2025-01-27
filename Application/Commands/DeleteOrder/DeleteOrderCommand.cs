using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
