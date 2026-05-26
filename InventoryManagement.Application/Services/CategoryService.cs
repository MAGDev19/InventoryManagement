using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Models;
using Microsoft.Extensions.Options;

namespace InventoryManagement.Application.Services
{
    public class CategoryService : _Service, ICategoryService
    {
        public CategoryService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }
    }
}
