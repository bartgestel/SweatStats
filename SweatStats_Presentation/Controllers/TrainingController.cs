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
            IOefeningDAL oefeningDal = new OefeningDAL();
            TrainingViewModel trainingModel = new TrainingViewModel();
            Training trainging = training.GetTraining(id);
            List<Oefening> oefeningen = training.GetOefeningen(oefeningDal, id);
            foreach (Oefening oefening in oefeningen)
            {
                trainingModel.oefeningen.Add(new OefeningViewModel { Id = oefening.Id, Name = oefening.Name });
            }
            trainingModel.Id = trainging.Id;
            trainingModel.Name = trainging.Name;
            return View(trainingModel);
        }
    }
}
