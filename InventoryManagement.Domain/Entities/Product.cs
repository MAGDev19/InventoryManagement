namespace InventoryManagement.Domain.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int StateId { get; set; }
        public int CategoryId { get; set; }
        public State State { get; set; }
        public Category Category { get; set; }
    }
}
