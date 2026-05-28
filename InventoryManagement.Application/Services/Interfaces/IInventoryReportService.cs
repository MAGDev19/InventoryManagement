using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Application.Services.Interfaces
{
    public interface IInventoryReportService
    {
        ResultOperation<InventorySummaryDto>
            GetInventorySummary();
    }
}