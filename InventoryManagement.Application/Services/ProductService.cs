using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities.CustomEntities;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Domain.Models.Farma.Core;
using InventoryManagement.Infrastructure.Repositories.Interfaces;
using InventoryManagement.Infrastructure.Repositories._UnitOfWork;
using Models.Dto;

namespace InventoryManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public ResultOperation<GenericoResponse> GetListProduct(QueryFilter entity)
        {
            var rst = new ResultOperation<GenericoResponse>();

            try
            {
                var productList = _productRepository.GetListProduct();

                if (productList.Count == 0)
                {
                    rst.MessageResult = "No hay datos";
                }

                var response = PagedList<ProductManagerDto>.Create(
                    productList,
                    entity.PageNumber,
                    100000);

                rst.Result = new GenericoResponse
                {
                    PagedProduct = response
                };

                rst.stateOperation = true;
            }
            catch (Exception ex)
            {
                rst.RollBack = true;
                rst.stateOperation = false;
                rst.MessageExceptionTechnical =
                    ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return rst;
        }

        public ResultOperation<ProductManagerDto> GetProductById(int id)
        {
            var rst = new ResultOperation<ProductManagerDto>();

            try
            {
                var product = _productRepository.GetProductById(id);

                if (product == null)
                {
                    rst.stateOperation = true;
                    rst.MessageResult = "No existen productos registrados";
                    return rst;
                }

                rst.Result = product;
                rst.stateOperation = true;
            }
            catch (Exception ex)
            {
                rst.RollBack = true;
                rst.stateOperation = false;
                rst.MessageExceptionTechnical =
                    ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return rst;
        }

        public ResultOperation<bool> PostProduct(ProductManagerDto product)
        {
            var rst = new ResultOperation<bool>();

            try
            {
                if (product.Stock < 0)
                {
                    rst.Result = false;
                    rst.stateOperation = false;
                    rst.MessageResult = "El stock no puede ser negativo";
                    return rst;
                }

                if (_productRepository.ExistSKU(product.SKU))
                {
                    rst.Result = false;
                    rst.stateOperation = false;
                    rst.MessageResult = "El SKU ya existe";
                    return rst;
                }

                _unitOfWork.Begin();

                rst.Result = _productRepository.PostProduct(product);

                if (rst.Result)
                {
                    _unitOfWork.Commit();

                    rst.stateOperation = true;
                    rst.MessageResult = "Producto creado correctamente";
                }
                else
                {
                    _unitOfWork.Rollback();

                    rst.stateOperation = false;
                    rst.MessageResult = "No fue posible crear el producto";
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                rst.RollBack = true;
                rst.stateOperation = false;
                rst.MessageExceptionTechnical =
                    ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return rst;
        }

        public ResultOperation<bool> UpdateProduct(ProductManagerDto product)
        {
            var rst = new ResultOperation<bool>();

            try
            {
                if (product.Stock < 0)
                {
                    rst.Result = false;
                    rst.stateOperation = false;
                    rst.MessageResult = "El stock no puede ser negativo";
                    return rst;
                }

                if (_productRepository.ExistSKUUpdate(product.IdProduct, product.SKU))
                {
                    rst.Result = false;
                    rst.stateOperation = false;
                    rst.MessageResult = "El SKU ya existe";
                    return rst;
                }

                _unitOfWork.Begin();

                rst.Result = _productRepository.UpdateProduct(product);

                if (rst.Result)
                {
                    _unitOfWork.Commit();

                    rst.stateOperation = true;
                    rst.MessageResult = "Producto actualizado correctamente";
                }
                else
                {
                    _unitOfWork.Rollback();

                    rst.stateOperation = false;
                    rst.MessageResult = "No fue posible actualizar el producto";
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                rst.RollBack = true;
                rst.stateOperation = false;
                rst.MessageExceptionTechnical =
                    ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return rst;
        }

        public ResultOperation<bool> DeleteProduct(int productId)
        {
            var rst = new ResultOperation<bool>();

            try
            {
                _unitOfWork.Begin();

                rst.Result = _productRepository.DeleteProduct(productId);

                if (rst.Result)
                {
                    _unitOfWork.Commit();
                    rst.stateOperation = true;
                }
                else
                {
                    _unitOfWork.Rollback();
                    rst.stateOperation = false;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                rst.RollBack = true;
                rst.stateOperation = false;
                rst.MessageExceptionTechnical =
                    ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return rst;
        }
    }
}