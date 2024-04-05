using Microsoft.AspNetCore.Mvc;

namespace SweatStats.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
