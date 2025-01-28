using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetAllRawMaterials
{
    public class GetAllClientsQuery : IRequest<List<RawMaterialsViewModel>>
    {
        public GetAllClientsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
