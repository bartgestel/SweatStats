using MySqlConnector;
using SweatStats_Logic;

namespace SweatStats_DAL
{
    public class UserDAL : IUserDAL
    {
        MySqlConnection conn = new MySqlConnection("server=86.81.232.42;user=school;database=SweatStats;port=3306;password=hihiyup");
        public bool RegisterUser(string username, string password, string email)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO users (username, password, email) VALUES (@username, @password, @email)", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
    }
}
