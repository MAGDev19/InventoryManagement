namespace InventoryManagement.Domain.Entities
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
