using System.Collections.Generic;

namespace Core.Entities
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity(
            string name,
            string cPF,
            string address,
            string telephone,
            string email,
            ICollection<OrderEntity> orders = null)
        {
            Name = name;
            CPF = cPF;
            Address = address;
            Telephone = telephone;
            Email = email;
            Orders = orders ?? new List<OrderEntity>();
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
