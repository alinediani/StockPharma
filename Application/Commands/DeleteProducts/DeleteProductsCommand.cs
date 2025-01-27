using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteProduct
{
    public class DeleteProductsCommand : IRequest<Unit>
    {
        public DeleteProductsCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
