using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweatStats_Logic.Interfaces
{
    public interface IOefeningDAL
    {
        List<Oefening> getOefeningen();

        void AddOefening(string name, int sets, int minReps, int maxReps, decimal weightKg, int trainingId);

        List<Oefening> GetOefeningen(int id);

        void DeleteOefening(int id);

        Oefening GetOefening(int id);

        void UpdateOefening(int id, int sets, int minReps, int maxReps, decimal weightKg);
        
        void UpdateWeight(int id, decimal weightKg);

        void LogExercise(int id, int reps, decimal weightKg);
        
        List<OefeningLog> GetOefeningLogs(int id);
    }
}
