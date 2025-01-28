using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductsViewModel>>
    {
        public GetAllProductsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
