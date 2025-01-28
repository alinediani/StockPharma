﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ClientsViewModel
    {
        public ClientsViewModel(int id,string name, string description, string supplierId, float amount, int uoM, DateTime expiration)
        {
            Id = id;
            Name = name;
            Description = description;
            SupplierId = supplierId;
            Amount = amount;
            UoM = uoM;
            Expiration = expiration;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public float Amount { get; set; }
        public int UoM { get; set; }
        public DateTime Expiration { get; set; }
    }
}
