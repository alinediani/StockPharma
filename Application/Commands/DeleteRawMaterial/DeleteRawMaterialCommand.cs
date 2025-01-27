using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteRawMaterial
{
    public class DeleteRawMaterialsCommand : IRequest<Unit>
    {
        public DeleteRawMaterialsCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
