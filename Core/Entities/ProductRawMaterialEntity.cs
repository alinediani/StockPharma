namespace Core.Entities
{
    public class ProductRawMaterialEntity
    {
        public int ProductRawMaterialId { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int RawMaterialId { get; set; }
        public RawMaterialEntity RawMaterial { get; set; }
        public float Quantity { get; set; }
    }
}
