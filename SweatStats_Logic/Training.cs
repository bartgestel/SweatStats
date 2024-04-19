using SweatStats_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SweatStats_Logic
{
    public class Training
    {
        public ITrainingDAL Dal { get; }

        public IOefeningDAL OefeningDal { get; }
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public Training(ITrainingDAL dal)
        {
            Dal = dal;
        }

        public bool AddTraining(string name)
        {
            return Dal.AddTraining(name);
        }

        public List<Training> GetAllTrainings()
        {
            return Dal.GetAllTrainings(1);
        }

        public bool DeleteTraining(int id)
        {
            return Dal.DeleteTraining(id);
        }

        public Training GetTraining(int id)
        {
            return Dal.GetTraining(id);
        }

        public List<Oefening> GetOefeningen(IOefeningDAL dal)
        {
            return dal.GetOefeningen(Id);
        }

    }
}
