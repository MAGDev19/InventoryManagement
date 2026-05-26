using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities.CustomEntities;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Domain.Models.Farma.Core;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Models.Dto;

namespace InventoryManagement.Application.Services
{
    public class CategoryService : _Service, ICategoryService
    {
        public CategoryService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        public ResultOperation<GenericoResponse> GetListCategory(QueryFilter entity)
        {
            var result =
                WrapExecuteTrans<ResultOperation<GenericoResponse>, CategoryRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<GenericoResponse>();
                    var CategoryList = new List<CategoryManagementDto>();

                    try
                    {
                        CategoryList = repo.GetListCategory();
                        if (CategoryList.Count == 0)
                        {
                            rst.MessageResult = "No hay datos";
                        }

                        var response = PagedList<CategoryManagementDto>.Create(CategoryList, entity.PageNumber, 100000);
                        rst.Result = new GenericoResponse { PagedCategory = response };
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }

        public ResultOperation<CategoryManagementDto> GetCategoryById(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<CategoryManagementDto>, CategoryRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<CategoryManagementDto>();

                    try
                    {
                        var task = repo.GetCategoryById(id);

                        if (task == null)
                        {
                            rst.stateOperation = true;
                            rst.MessageResult = "No existen categorías registradas";
                            return rst;
                        }

                        rst.Result = task;
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }


        public ResultOperation<bool> PostCategory(CategoryManagementDto category)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, CategoryRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.PostCategory(category);
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }

        public ResultOperation<bool> UpdateCategory(CategoryManagementDto category)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, CategoryRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.UpdateCategory(category);
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}";
                }

                return rst;
            });

            return result;
        }

        public ResultOperation<bool> DeleteCategory(int CategoryId)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, CategoryRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.DeleteCategory(CategoryId);
                        rst.stateOperation = true;
                    }
                    catch (Exception err)
                    {
                        rst.RollBack = true;
                        rst.stateOperation = false;
                        rst.MessageExceptionTechnical = err.Message + Environment.NewLine + err.StackTrace;
                    }

                    return rst;
                });

            return result;
        }
    }
}
