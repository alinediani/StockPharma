using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public OrderEntity(ClientEntity client, List<OrderProductEntity> orderProducts, int amount, DateTime orderDate, double totalCoast)
        {
            Client = client;
            OrderProducts = orderProducts;
            Amount = amount;
            OrderDate = orderDate;
            TotalCoast = totalCoast;
        }

        public ClientEntity Client { get; set; }
        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }
}
