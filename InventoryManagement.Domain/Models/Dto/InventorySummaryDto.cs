namespace InventoryManagement.Domain.Models.Dto
{
    public class InventorySummaryDto
    {
        public List<CategorySummaryDto> InventoryByCategory { get; set; }
        public List<CriticalStockDto> CriticalProducts { get; set; }
        public decimal OccupationPercentage { get; set; }
    }

    public class CategorySummaryDto
    {
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalProducts { get; set; }
        public int TotalStock { get; set; }
    }

    public class CriticalStockDto
    {
        public int IdProduct { get; set; }
        public string SKU { get; set; }
        public string NameProduct { get; set; }
        public int Stock { get; set; }
    }
}
