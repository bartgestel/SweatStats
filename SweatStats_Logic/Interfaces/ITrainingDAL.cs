using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweatStats_Logic.Interfaces
{
    public interface ITrainingDAL
    {
        bool AddTraining(string name);

        List<Training> GetAllTrainings(int id);

        bool DeleteTraining(int id);

        Training GetTraining(int id);

    }
}
