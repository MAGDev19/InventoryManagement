using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IInventoryReportRepository
    {
        InventorySummaryDto GetInventorySummary();
    }
}
