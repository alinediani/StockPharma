using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        public OrderEntity(ClientEntity client, List<ProductEntity> products, int amount, DateTime orderDate, double totalCoast)
        {
            Client = client;
            Products = products;
            Amount = amount;
            OrderDate = orderDate;
            TotalCoast = totalCoast;
        }

        public ClientEntity Client { get; set; }
        public List<ProductEntity> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }

        //Ajustar o relacionamento de custo e quantidade com pedido para fazer a soma corretamente
    }
}
