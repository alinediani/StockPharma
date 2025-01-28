using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using MediatR;

namespace Application.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<OrdersViewModel>>
    {
        public GetAllOrdersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
