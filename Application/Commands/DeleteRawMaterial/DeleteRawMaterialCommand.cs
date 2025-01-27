using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteRawMaterial
{
    public class DeleteRawMaterialCommand : IRequest<Unit>
    {
        public DeleteRawMaterialCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
