using Microsoft.AspNetCore.Mvc;

namespace FýrstCSBackend.Controllers
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
