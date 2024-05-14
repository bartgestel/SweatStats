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

        public IActionResult Details(int id)
        {
            ITrainingDAL dal = new TrainingDAL();
            Training training = new Training(dal);
            IOefeningDAL oefeningDal = new OefeningDAL();
            TrainingViewModel trainingModel = new TrainingViewModel();
            Training trainging = training.GetTraining(id);
            List<Oefening> oefeningen = training.GetOefeningen(oefeningDal, id);
            foreach (Oefening oefening in oefeningen)
            {
                trainingModel.oefeningen.Add(new OefeningViewModel { Id = oefening.Id, Name = oefening.Name, weightKg = oefening.weightKg, Sets = oefening.Sets, minReps = oefening.minReps, maxReps = oefening.maxReps});
            }
            trainingModel.Id = trainging.Id;
            trainingModel.Name = trainging.Name;
            return View(trainingModel);
        }

        public IActionResult Training(int id)
        {
            ITrainingDAL dal = new TrainingDAL();
            Training training = new Training(dal);
            IOefeningDAL oefeningDal = new OefeningDAL();
            List<Oefening> oefeningen = training.GetOefeningen(oefeningDal, id);
            if (oefeningen.Count > 0)
            {
                OefeningViewModel oefeningModel = new OefeningViewModel { Id = oefeningen[0].Id, Name = oefeningen[0].Name, weightKg = oefeningen[0].weightKg, Sets = oefeningen[0].Sets, minReps = oefeningen[0].minReps, maxReps = oefeningen[0].maxReps };
                return View(oefeningModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Training()
        {
            
            return View();
        }
        
        public IActionResult UpdateWeight(int id, decimal weight)
        {
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            oefening.UpdateWeight(id, weight);
            return RedirectToAction("Details", new { id = id });
        }
    }
}
