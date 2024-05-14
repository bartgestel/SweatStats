using MySqlConnector;
using SweatStats_Logic;
using SweatStats_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
                int oefeningId = reader.GetInt32("oefening_id");
                oefening.Name = getOefeningName(oefeningId);
                oefening.Sets = reader.GetInt32("sets");
                oefening.minReps = reader.GetInt32("min_reps");
                oefening.maxReps = reader.GetInt32("max_reps");
                oefening.weightKg = reader.GetDecimal("weight_kg");
                oefeningen.Add(oefening);
                Debug.WriteLine(oefening.Name);
            }
            conn.Close();
            return oefeningen;
        }

        private string getOefeningName(int oefeningId)
        {
            MySqlConnection conn2 = new MySqlConnection("server=86.81.232.42;user=bart;database=SweatStats;port=3306;password=3108Bfh*");
            string oefeningName = "";
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM oefeningen WHERE id = @id", conn2);
            cmd2.Parameters.AddWithValue("@id", oefeningId);
            conn2.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                oefeningName = reader2.GetString("naam");
            }
            reader2.Close();
            conn2.Close();
            return oefeningName;
        }

        public void DeleteOefening(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM training_oefening WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Oefening GetOefening(int id)
        {
            int oefeningId = 0;

            Oefening oefening = new Oefening(this);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM training_oefening WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                oefening.Id = reader.GetInt32("id");
                oefening.Sets = reader.GetInt32("sets");
                oefening.minReps = reader.GetInt32("min_reps");
                oefening.maxReps = reader.GetInt32("max_reps");
                oefening.weightKg = reader.GetDecimal("weight_kg");
                oefeningId = reader.GetInt32("oefening_id");
            }
            reader.Close();

            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT * FROM oefeningen WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", oefeningId);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                oefening.Name = reader.GetString("naam");
            }
            conn.Close();
            return oefening;
        }

        public void UpdateOefening(int id, int sets, int minReps, int maxReps, decimal weightKg)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE training_oefening SET sets = @sets, min_reps = @minReps, max_reps = @maxReps, weight_kg = @weightKg WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@sets", sets);
            cmd.Parameters.AddWithValue("@minReps", minReps);
            cmd.Parameters.AddWithValue("@maxReps", maxReps);
            cmd.Parameters.AddWithValue("@weightKg", weightKg);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public void UpdateWeight(int id, decimal weightKg)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE training_oefening SET weight_kg = @weightKg WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@weightKg", weightKg);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
