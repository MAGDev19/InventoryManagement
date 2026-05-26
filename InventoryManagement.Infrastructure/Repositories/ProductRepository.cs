using Dapper;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Infrastructure.Repositories._UnitOfWork;
using InventoryManagement.Infrastructure.Repositories.Interfaces;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository() { }
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public List<ProductManagerDto> GetListProduct()
        {
            var response = GetDataListOfProcedure<ProductManagerDto>("sp_GetListProduct");
            return response;
        }

        public ProductManagerDto GetProductById(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("@IdProduct", id);

            var result = GetDataListOfProcedure<ProductManagerDto>("Sp_GetProductById", prms)
                         .FirstOrDefault();
            return result;
        }

        public bool PostProduct(ProductManagerDto product)
        {
            var prms = new DynamicParameters();

            prms.Add("@SKU", product.SKU);
            prms.Add("@NameProduct", product.NameProduct);
            prms.Add("@Description", product.Description);
            prms.Add("@Stock", product.Stock);
            prms.Add("@Price", product.Price);
            prms.Add("@DueDate", product.DueDate);
            prms.Add("@CreatedAt", product.CreatedAt);
            prms.Add("@UpdatedAt", product.UpdatedAt);
            prms.Add("@StateId", product.StateId);
            prms.Add("@CategoryId", product.CategoryId);

            var response = Execute<int>("Sp_PostProduct", prms) == 1 ? true : false;

            return response;
        }

        public bool UpdateProduct(ProductManagerDto product)
        {
            var prms = new DynamicParameters();

            prms.Add("@IdProduct", product.IdProduct);
            prms.Add("@SKU", product.SKU);
            prms.Add("@NameProduct", product.NameProduct);
            prms.Add("@Description", product.Description);
            prms.Add("@Stock", product.Stock);
            prms.Add("@Price", product.Price);
            prms.Add("@DueDate", product.DueDate);
            prms.Add("@UpdatedAt", product.UpdatedAt);
            prms.Add("@StateId", product.StateId);
            prms.Add("@CategoryId", product.CategoryId);

            var response = Execute<int>("Sp_UpdateProduct", prms) == 1 ? true : false;

            return response;
        }
        public bool DeleteProduct(int productId)
        {
            var prms = new DynamicParameters();
            prms.Add("IdProduct", productId);
            var response = Execute<int>("Sp_DeleteProduct", prms) == -1 ? true : false;
            return response;
        }
    }
}
