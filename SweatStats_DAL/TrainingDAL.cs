using MySqlConnector;
using SweatStats_Logic;
using SweatStats_Logic.Interfaces;
using System.Collections.Generic;

namespace SweatStats_DAL
{
    public class TrainingDAL : ITrainingDAL
    {
        MySqlConnection conn = new MySqlConnection("server=86.81.232.42;user=bart;database=SweatStats;port=3306;password=3108Bfh*");
        public bool AddTraining(string name)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO trainingen (naam, user_id) VALUES (@name, @userId)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userId", 1);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public List<Training> GetAllTrainings(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM trainingen WHERE user_id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Training> trainings = new List<Training>();
            while (reader.Read())
            {
                Training training = new Training(this);
                training.Id = reader.GetInt32("id");
                training.Name = reader.GetString("naam");
                trainings.Add(training);
            }
            conn.Close();
            return trainings;
            
        }

        public bool DeleteTraining(int id)
        {
            conn.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM training_oefening WHERE training_id = @id", conn);
            mySqlCommand.Parameters.AddWithValue("@id", id);
            mySqlCommand.ExecuteNonQuery();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM trainingen WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public Training GetTraining(int id)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM trainingen WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            Training training = new Training(this);
            while (reader.Read())
            {
                training.Id = reader.GetInt32("id");
                training.Name = reader.GetString("naam");
            }
            conn.Close();
            return training;
        }
    }
}
