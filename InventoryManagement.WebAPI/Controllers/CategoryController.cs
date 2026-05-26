using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.WebAPI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
