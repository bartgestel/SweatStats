using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweatStats.Models;
using SweatStats_DAL;
using SweatStats_Logic;
using System.Diagnostics;

namespace SweatStats.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IUserDAL dal = new UserDAL();
                User user = new User(dal);
                if(user.RegisterUser(model.Username, model.Password, model.Email))
                {
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
