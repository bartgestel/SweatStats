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
    }
}
