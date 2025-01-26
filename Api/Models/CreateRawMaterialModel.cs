namespace Api.Models
{
    public class CreateRawMaterialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public float Amount { get; set; }
        public int UoM { get; set; }
        public string Expiration { get; set; }
    }
}
