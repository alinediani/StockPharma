using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class OrderEntity : BaseEntity
    {
        // Construtor sem parâmetros para o EF Core
        public OrderEntity()
        {
            OrderProducts = new List<OrderProductEntity>();  // Inicializa a coleção de produtos
        }

        // Construtor com parâmetros
        public OrderEntity(int clientId, ClientEntity client, List<OrderProductEntity> orderProducts, int amount, DateTime orderDate, double totalCoast)
        {
            ClientId = clientId;
            Client = client;
            OrderProducts = orderProducts ?? new List<OrderProductEntity>();  // Evita nulo
            Amount = amount;
            OrderDate = orderDate;
            TotalCoast = totalCoast;
        }

        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }  // Relacionamento com Cliente

        // Lista de produtos no pedido
        public List<OrderProductEntity> OrderProducts { get; set; }

        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }
}
