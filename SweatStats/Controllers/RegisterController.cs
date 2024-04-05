using Microsoft.AspNetCore.Mvc;

namespace SweatStats.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
