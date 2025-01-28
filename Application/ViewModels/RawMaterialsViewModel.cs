using Application.ViewModels;

public class RawMaterialsViewModel
{
    public RawMaterialsViewModel(int id, string name, string description, string supplierId, float amount, int uoM, DateTime expiration, List<ProductRawMaterialViewModel> products)
    {
        Id = id;
        Name = name;
        Description = description;
        SupplierId = supplierId;
        Amount = amount;
        UoM = uoM;
        Expiration = expiration;
        Products = products;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SupplierId { get; set; }
    public float Amount { get; set; }
    public int UoM { get; set; }
    public DateTime Expiration { get; set; }
    public List<ProductRawMaterialViewModel> Products { get; set; }
}
