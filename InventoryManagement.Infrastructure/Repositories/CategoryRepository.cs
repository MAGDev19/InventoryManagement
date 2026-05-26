using Dapper;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Infrastructure.Repositories._UnitOfWork;
using InventoryManagement.Infrastructure.Repositories.Interfaces;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository() { }
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public List<CategoryManagementDto> GetListCategory()
        {
            var response = GetDataListOfProcedure<CategoryManagementDto>("sp_GetListCategory");
            return response;
        }

        public CategoryManagementDto GetCategoryById(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("@IdCategory", id);

            var result = GetDataListOfProcedure<CategoryManagementDto>("Sp_GetCategoryById", prms)
                         .FirstOrDefault();
            return result;
        }

        public bool PostCategory(CategoryManagementDto category)
        {
            var prms = new DynamicParameters();
            prms.Add("@NameCategory", category.NameCategory);
            prms.Add("@Description", category.Description);
            prms.Add("@CreatedAt", category.CreatedAt);
            prms.Add("@UpdatedAt", category.UpdatedAt);

            var responseDos = Execute<int>("Sp_PostCategory", prms);
            var response = Execute<int>("Sp_PostCategory", prms) == -1 ? true : false;

            return response;
        }

        public bool UpdateCategory(CategoryManagementDto category)
        {
            var prms = new DynamicParameters();

            prms.Add("@IdCategory", category.IdCategory);
            prms.Add("@NameCategory", category.NameCategory);
            prms.Add("@Description", category.Description);
            prms.Add("@CreatedAt", category.CreatedAt);
            prms.Add("@UpdatedAt", category.UpdatedAt);

            var response = Execute<int>("Sp_UpdateCategory", prms) == 1 ? true : false;

            return response;
        }
        public bool DeleteCategory(int CategoryId)
        {
            var prms = new DynamicParameters();
            prms.Add("IdCategory", CategoryId);
            var response = Execute<int>("Sp_DeleteCategory", prms) == -1 ? true : false;
            return response;
        }
    }
}
