using Dapper;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Infrastructure.Repositories._UnitOfWork;
using InventoryManagement.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoryReportRepository : Repository, IInventoryReportRepository
    {
        public InventoryReportRepository() { }

        public InventoryReportRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
        public InventorySummaryDto GetInventorySummary()
        {
            var response = new InventorySummaryDto();


            using (var multi = _unitOfWork.Connection.QueryMultiple("Sp_GetInventorySummary",
                commandType: CommandType.StoredProcedure))
            {
                response.InventoryByCategory =
                    multi.Read<CategorySummaryDto>().ToList();

                response.CriticalProducts =
                    multi.Read<CriticalStockDto>().ToList();

                response.OccupationPercentage =
                    multi.Read<decimal>().FirstOrDefault();
            }

            return response;
        }
    }
}