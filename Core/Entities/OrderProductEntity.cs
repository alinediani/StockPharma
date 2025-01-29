namespace Core.Entities
{
    public class OrderProductEntity 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }

    }
}
