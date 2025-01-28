using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IProductRawMaterialRepository
    {
        Task AddProductRawMaterialAsync(ProductRawMaterialEntity productRawMaterial);
        Task DeleteProductRawMaterialAsync(int productId, int rawMaterialId);
    }
}
