using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrdersViewModel>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
