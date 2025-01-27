using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetRawMaterialById
{
    public class GetRawMaterialByIdQuery : IRequest<RawMaterialsViewModel>
    {
        public GetRawMaterialByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
