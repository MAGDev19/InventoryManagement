using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<ProductManagerDto> GetListProduct();
        ProductManagerDto GetProductById(int id);
        bool PostProduct(ProductManagerDto product);
        bool UpdateProduct(ProductManagerDto product);
        bool DeleteProduct(int ProductId);
    }
}
