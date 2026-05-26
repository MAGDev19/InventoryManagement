namespace InventoryManagement.Domain.Models.Dto
{
    public class ProductManagerDto
    {
        public int IdProduct { get; set; }
        public string SKU { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int StateId { get; set; }
        public int CategoryId { get; set; }
    }
}
