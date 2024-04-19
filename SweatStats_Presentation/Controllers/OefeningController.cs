using Microsoft.AspNetCore.Mvc;
using SweatStats.Models;
using SweatStats_DAL;
using SweatStats_Logic;
using SweatStats_Logic.Interfaces;

namespace SweatStats.Controllers
{
    public class OefeningController : Controller
    {
        public IActionResult Add()
        {
            OefeningViewModel model = new OefeningViewModel();
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            List<Oefening> oefeningen = oefening.GetAllOefeningen();
            foreach (Oefening o in oefeningen)
            {
                model.oefeningen.Add(new OefeningViewModel { Id = o.Id, Name = o.Name });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(OefeningViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                IOefeningDAL dal = new OefeningDAL();
                Oefening oefening = new Oefening(dal);
                oefening.AddOefening(model.Name, model.Sets, model.minReps, model.maxReps, model.weightKg, id);
                return RedirectToAction("Index", "Training");
            }
            return View(model);
        }
    }
}
