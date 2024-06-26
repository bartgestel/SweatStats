﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Training()
        {
            
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult GetLogs(int id, int months)
        {
            IOefeningDAL dal = new OefeningDAL();
            OefeningLog oefeningLog = new OefeningLog(dal);
            List<OefeningLog> oefeningLogs = oefeningLog.GetOefeningLogs(id, months);
            return Json(oefeningLogs);
        }
        
        public void UpdateWeight(int id, decimal weight)
        {
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            oefening.UpdateWeight(id, weight);
        }

        public void LogExercise(int id, int reps, decimal weight)
        {
            IOefeningDAL dal = new OefeningDAL();
            Oefening oefening = new Oefening(dal);
            oefening.LogExercise(id, reps, weight);
        }
        
    }
}
