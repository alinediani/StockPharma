using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class OrdersViewModel
    {
        public OrdersViewModel(int id, ClientEntity client, List<ProductEntity> products, int amount, DateTime orderDate, double totalCoast)
        {
            Id = id;
            Client = client;
            Products = products;
            Amount = amount;
            OrderDate = orderDate;
            TotalCoast = totalCoast;
        }

        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public List<ProductEntity> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }
}
