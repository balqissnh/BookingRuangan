using bookingruangan.Helpers;
using MySql.Data.MySqlClient;

namespace bookingruangan
{
    public class LoginService
    {
        public static bool Authenticate(string username, string password)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
