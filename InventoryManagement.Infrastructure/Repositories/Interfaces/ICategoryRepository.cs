using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryManagementDto> GetListCategory();
        CategoryManagementDto GetCategoryById(int id);
        bool PostCategory(CategoryManagementDto category);
        bool UpdateCategory(CategoryManagementDto category);
        bool DeleteCategory(int CategoryId);
    }
}
