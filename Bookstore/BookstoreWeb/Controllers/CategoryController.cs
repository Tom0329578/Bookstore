using Microsoft.AspNetCore.Mvc;

namespace BookstoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
