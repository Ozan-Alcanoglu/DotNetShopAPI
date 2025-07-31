using Microsoft.AspNetCore.Mvc;

namespace FýrstCSBackend.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
