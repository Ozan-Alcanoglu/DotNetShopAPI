using Microsoft.AspNetCore.Mvc;

namespace FirstCSBackend.Controllers
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
