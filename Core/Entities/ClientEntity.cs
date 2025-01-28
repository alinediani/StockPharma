using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ClientEntity : BaseEntity
    {
        // Construtor sem parâmetros para o EF Core
        public ClientEntity() { }

        // Construtor com parâmetros
        public ClientEntity(string name, string cPF, string address, string telephone, string email, ICollection<OrderEntity> orders)
        {
            Name = name;
            CPF = cPF;
            Address = address;
            Telephone = telephone;
            Email = email;
            Orders = orders ?? new List<OrderEntity>();  // Inicializa a lista para evitar problemas
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        // Propriedade de navegação
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
