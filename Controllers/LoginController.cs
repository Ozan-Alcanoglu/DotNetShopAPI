using Microsoft.AspNetCore.Mvc;

namespace F�rstCSBackend.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
