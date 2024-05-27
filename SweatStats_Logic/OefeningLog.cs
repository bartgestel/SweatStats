using System;
using System.Collections.Generic;
using SweatStats_Logic.Interfaces;

namespace SweatStats_Logic
{
    public class OefeningLog
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Reps { get; set; }
        public decimal WeightKg { get; set; }
        public DateTime Date { get; set; }
        
        public IOefeningDAL Dal { get; }
        
        public OefeningLog(IOefeningDAL dal)
        {
            Dal = dal;
        }
        
        public List<OefeningLog> GetOefeningLogs(int id, int months)
        {
            return Dal.GetOefeningLogs(id, months);
        }
    }
}