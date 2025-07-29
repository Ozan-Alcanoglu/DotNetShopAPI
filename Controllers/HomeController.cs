using Microsoft.AspNetCore.Mvc;

namespace FirstCSBackend.Controllers
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
