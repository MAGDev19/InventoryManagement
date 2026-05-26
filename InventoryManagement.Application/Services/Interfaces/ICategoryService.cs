using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Domain.Models.Farma.Core;
using Models.Dto;

namespace InventoryManagement.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        ResultOperation<GenericoResponse> GetListCategory(QueryFilter entity);
        ResultOperation<CategoryManagementDto> GetCategoryById(int id);
        ResultOperation<bool> PostCategory(CategoryManagementDto category);
        ResultOperation<bool> UpdateCategory(CategoryManagementDto category);
        ResultOperation<bool> DeleteCategory(int CategoryId);
    }
}
