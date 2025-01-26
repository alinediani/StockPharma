using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Ao menos um produto deve ser selecionado.")]
        [MinLength(1, ErrorMessage = "Selecione pelo menos um produto.")]
        public List<Product> Products { get; set; } = new();

        [Required(ErrorMessage = "A data de criação é obrigatória.")]
        public DateTime CreatedDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser maior que zero.")]
        public double TotalValue { get; set; }
    }
}
