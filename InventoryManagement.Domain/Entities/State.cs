using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Entities
{
    public class State
    {
        public int IdState { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
