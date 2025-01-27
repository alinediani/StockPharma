using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity(string name, string cPF, string address, string telephone, string email)
        {
            Name = name;
            CPF = cPF;
            Address = address;
            Telephone = telephone;
            Email = email;
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
