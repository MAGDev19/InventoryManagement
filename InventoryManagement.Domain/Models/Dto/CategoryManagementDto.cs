namespace InventoryManagement.Domain.Models.Dto
{
    public class CategoryManagementDto
    {
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
