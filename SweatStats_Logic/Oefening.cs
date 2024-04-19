﻿using SweatStats_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweatStats_Logic
{
    public class Oefening
    {
        public IOefeningDAL Dal { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sets { get; set; }
        public int minReps { get; set; }
        public int maxReps { get; set; }
        public decimal weightKg { get; set; }
        
        public Oefening(IOefeningDAL dal)
        {
            Dal = dal;
        }

        public List<Oefening> GetAllOefeningen()
        {
            return Dal.getOefeningen();
        }

        public void AddOefening(string name, int sets, int minReps, int maxReps, decimal weightKg, int trainingId)
        {
            Dal.AddOefening(name, sets, minReps, maxReps, weightKg, trainingId);
        }
    }
}
