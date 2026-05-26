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
    public class ProductService : _Service, IProductService
    {
        public ProductService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        public ResultOperation<GenericoResponse> GetListProduct(QueryFilter entity)
        {
            var result =
                WrapExecuteTrans<ResultOperation<GenericoResponse>, ProductRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<GenericoResponse>();
                    var TaskList = new List<ProductManagerDto>();

                    try
                    {
                        TaskList = repo.GetListProduct();
                        if (TaskList.Count == 0)
                        {
                            rst.MessageResult = "No hay datos";
                        }

                        var response = PagedList<ProductManagerDto>.Create(TaskList, entity.PageNumber, 100000);
                        rst.Result = new GenericoResponse { PagedTasks = response };
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

        public ResultOperation<ProductManagerDto> GetProductById(int id)
        {
            var result =
                WrapExecuteTrans<ResultOperation<ProductManagerDto>, ProductRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<ProductManagerDto>();

                    try
                    {
                        var task = repo.GetProductById(id);

                        if (task == null)
                        {
                            rst.stateOperation = true;
                            rst.MessageResult = "No existen productos registrados";
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


        public ResultOperation<bool> PostProduct(ProductManagerDto product)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, ProductRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.PostProduct(product);
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

        public ResultOperation<bool> UpdateProduct(ProductManagerDto product)
        {
            var result = WrapExecuteTrans<ResultOperation<bool>, ProductRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.UpdateProduct(product);
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

        public ResultOperation<bool> DeleteProduct(int ProductId)
        {
            var result =
                WrapExecuteTrans<ResultOperation<bool>, ProductRepository>((repo, uow) =>
                {
                    var rst = new ResultOperation<bool>();

                    try
                    {
                        rst.Result = repo.DeleteProduct(ProductId);
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
