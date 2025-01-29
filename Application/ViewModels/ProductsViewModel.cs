public class ProductRawMaterialViewModel
{
    public ProductRawMaterialViewModel(int rawMaterialId, float quantity)
    {
        RawMaterialId = rawMaterialId;
        Quantity = quantity;
    }

    public int RawMaterialId { get; set; }
    public float Quantity { get; set; }
}
