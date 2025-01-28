﻿using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class OrdersViewModel
    {
        private ClientsViewModel clientsViewModel;
        private List<ProductsViewModel> productsViewModels;

        public OrdersViewModel(int id, ClientsViewModel client, List<OrderProductViewModel> products, int amount, DateTime orderDate, double totalCoast)
        {
            Id = id;
            Client = client;
            Products = products;
            Amount = amount;
            OrderDate = orderDate;
            TotalCoast = totalCoast;
        }

        public int Id { get; set; }
        public ClientsViewModel Client { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalCoast { get; set; }
    }

    public class OrderProductViewModel
    {
        public OrderProductViewModel(int productId, string productName, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; } // Quantidade do produto no pedido
    }
}
