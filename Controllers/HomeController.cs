using Microsoft.AspNetCore.Mvc;

namespace F�rstCSBackend.Controllers
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
