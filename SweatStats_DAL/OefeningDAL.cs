using MySqlConnector;
using SweatStats_Logic;
using SweatStats_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SweatStats_DAL
{
    public class OefeningDAL : IOefeningDAL
    {
        MySqlConnection conn = new MySqlConnection("server=86.81.232.42;user=bart;database=SweatStats;port=3306;password=3108Bfh*");
        public List<Oefening> getOefeningen()
        {
            conn.Open();
            List<Oefening> oefeningen = new List<Oefening>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM oefeningen", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Oefening oefening = new Oefening(this);
                oefening.Id = reader.GetInt32("id");
                oefening.Name = reader.GetString("naam");
                oefeningen.Add(oefening);
            }
            conn.Close();
            reader.Close();
            return oefeningen;
        }

        public void AddOefening(string name, int sets, int minReps, int maxReps, decimal weightKg, int trainingId)
        {
            conn.Open();
            int oefeningId = 0;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM oefeningen WHERE naam = @naam", conn);
            cmd.Parameters.AddWithValue("@naam", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                oefeningId = reader.GetInt32("id");
            }
            reader.Close();
            
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO training_oefening (oefening_id, training_id, sets, min_reps, max_reps, weight_kg) VALUES (@oefeningId, @trainingId, @sets, @minReps, @maxReps, @weightKg)";
            cmd.Parameters.AddWithValue("@oefeningId", oefeningId);
            cmd.Parameters.AddWithValue("@trainingId", trainingId);
            cmd.Parameters.AddWithValue("@sets", sets);
            cmd.Parameters.AddWithValue("@minReps", minReps);
            cmd.Parameters.AddWithValue("@maxReps", maxReps);
            cmd.Parameters.AddWithValue("@weightKg", weightKg);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Oefening> GetOefeningen(int id)
        {
            List<Oefening> oefeningen = new List<Oefening>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM training_oefening WHERE training_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Oefening oefening = new Oefening(this);
                oefening.Id = reader.GetInt32("id");
                oefening.Name = reader.GetString("naam");
                oefeningen.Add(oefening);
                Debug.WriteLine(oefening.Name);
            }

            return oefeningen;
        }
    }
}
