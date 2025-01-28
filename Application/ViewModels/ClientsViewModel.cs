using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ClientsViewModel
    {
        public ClientsViewModel(int id, string name, string cPF, string address, string telephone, string email)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            Address = address;
            Telephone = telephone;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; } 
        public string CPF { get; set; } 
        public string Address { get; set; } 
        public string Telephone { get; set; } 
        public string Email { get; set; } 
        public List<OrdersViewModel> Orders { get; set; }
    }
}
