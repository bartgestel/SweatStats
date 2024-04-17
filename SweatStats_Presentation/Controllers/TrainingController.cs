using Microsoft.AspNetCore.Mvc;
using SweatStats.Models;
using SweatStats_DAL;
using SweatStats_Logic;
using SweatStats_Logic.Interfaces;

namespace SweatStats.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            TrainingViewModel model = new TrainingViewModel();
            ITrainingDAL dal = new TrainingDAL();
            Training training = new Training(dal);
            List<Training> trainings = training.GetAllTrainings();
            foreach (Training trainging in trainings)
            {
                model.trainings.Add(new TrainingViewModel { Id = trainging.Id, Name = trainging.Name });
            }
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                ITrainingDAL dal = new TrainingDAL();
                Training trainging = new Training(dal);
                trainging.AddTraining(model.Name);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ITrainingDAL dal = new TrainingDAL();
            Training training = new Training(dal);
            training.DeleteTraining(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ITrainingDAL dal = new TrainingDAL();
            Training training = new Training(dal);
            TrainingViewModel model = new TrainingViewModel();
            Training trainging = training.GetTraining(id);
            model.Id = trainging.Id;
            model.Name = trainging.Name;
            return View(model);
        }
    }
}
