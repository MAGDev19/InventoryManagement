using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Domain.Models.Farma.Core;
using Models.Dto;

namespace InventoryManagement.Application.Services.Interfaces
{
    public interface IProductService
    {
        ResultOperation<GenericoResponse> GetListProduct(QueryFilter entity);
        ResultOperation<ProductManagerDto> GetProductById(int id);
        ResultOperation<bool> PostProduct(ProductManagerDto product);
        ResultOperation<bool> UpdateProduct(ProductManagerDto product);
        ResultOperation<bool> DeleteProduct(int ProductId);
    }
}
