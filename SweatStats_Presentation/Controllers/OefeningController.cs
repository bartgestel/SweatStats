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
                return RedirectToAction("Edit", "Training", new {id = id});
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            oefening.DeleteOefening(id);
            return RedirectToAction("Index", "Training");
        }

        public IActionResult Edit(int id)
        {
            OefeningViewModel model = new OefeningViewModel();
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            Oefening o = oefening.GetOefening(id);
            model.Id = o.Id;
            model.Name = o.Name;
            model.Sets = o.Sets;
            model.minReps = o.minReps;
            model.maxReps = o.maxReps;
            model.weightKg = o.weightKg;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(OefeningViewModel model, int id)
        {
            model.Name = "Ik moet hier iets invullen i guess";
            if (ModelState.IsValid)
            {
                IOefeningDAL dal = new OefeningDAL();
                Oefening oefening = new Oefening(dal);
                oefening.UpdateOefening(id, model.Sets, model.minReps, model.maxReps, model.weightKg);
                return RedirectToAction("Index", "Training");
            }
            return View(model);
        }
    }
}
